using ProvaPub.Interfaces.Repository;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class CustomerService
    {
        private const int ItemPerPage = 10;
        public ICustomerRepository _customerRepository { get; set; }

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerList ListCustomers(int page)
        {
            var customerQueryable = _customerRepository.FindAllQueryable();
            var listProducts = customerQueryable.Skip(page * ItemPerPage).Take(ItemPerPage).ToList();
            var hasNext = (customerQueryable.Count() / ItemPerPage) > (page + 1);

            return new CustomerList()
                { HasNext = hasNext, TotalCount = listProducts.Count(), Customers = listProducts };
        }


        public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
        {
          // if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

          // if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));

          // //Business Rule: Non registered Customers cannot purchase
          // var customer = await _customerRepository.CustomerQueryable().FindAsync(customerId);
          // if (customer == null) throw new InvalidOperationException($"Customer Id {customerId} does not exists");

          // //Business Rule: A customer can purchase only a single time per month
          // var baseDate = DateTime.UtcNow.AddMonths(-1);
          // var ordersInThisMonth =
          //     await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
          // if (ordersInThisMonth > 0)
          //     return false;

          // //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00
          // var haveBoughtBefore = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
          // if (haveBoughtBefore == 0 && purchaseValue > 100)
          //     return false;

            return true;
        }
    }
}