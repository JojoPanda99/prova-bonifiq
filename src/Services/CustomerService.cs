using ProvaPub.Dtos;
using ProvaPub.Interfaces.Repository;
using ProvaPub.Interfaces.Services;
using ProvaPub.Models;

namespace ProvaPub.Services;

public class CustomerService : ICustomerService
{
    private const int ItemPerPage = 10;
    private readonly ICustomerRepository _customerRepository;
    private readonly IOrderRepository _orderRepository;

    public CustomerService(ICustomerRepository customerRepository, IOrderRepository orderRepository)
    {
        _customerRepository = customerRepository;
        _orderRepository = orderRepository;
    }

    public async Task<CustomersPaginatedDto> ListCustomersAsync(int page)
    {
        var customersPaginated = await _customerRepository.GetAllPaginatedAsync(page, ItemPerPage);
        var customersCount = await _customerRepository.CountAsync();
        var hasNext = (customersCount / ItemPerPage) > (page + 1);

        return new CustomersPaginatedDto
        {
            HasNext = hasNext,
            TotalCount = customersCount,
            Customers = customersPaginated
        };
    }

    public async Task<bool> CanPurchaseAsync(int customerId, decimal purchaseValue)
    {
        if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

        if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));

        //Business Rule: Non registered Customers cannot purchase
        var customer = await _customerRepository.FindByIdAsync(customerId);
        if (customer == null) throw new InvalidOperationException($"Customer Id {customerId} does not exists");

        //Business Rule: A customer can purchase only a single time per month
        var baseDate = DateTime.UtcNow.AddMonths(-1);
        var ordersInThisMonth = await _orderRepository
            .CountOrdersInMonthByCustomerIdAsync(customerId, baseDate);
        if (ordersInThisMonth > 0)
            return false;

        //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00
        var haveBoughtBefore = await _customerRepository.CountCustomersWithOrdersByCustomerId(customerId);
        if (haveBoughtBefore == 0 && purchaseValue > 100)
            return false;

        return true;
    }
}