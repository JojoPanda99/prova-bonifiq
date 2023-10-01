using ProvaPub.Dtos;
using ProvaPub.Models;

namespace ProvaPub.Interfaces.Services;

public interface ICustomerService
{
    Task<CustomersPaginatedDto> ListCustomersAsync(int page);
    Task<bool> CanPurchaseAsync(int customerId, decimal purchaseValue);
}