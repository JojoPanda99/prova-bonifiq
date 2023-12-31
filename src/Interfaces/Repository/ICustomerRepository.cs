using ProvaPub.Models;

namespace ProvaPub.Interfaces.Repository;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    Task<int> CountCustomersWithOrdersByCustomerId(int customerId);
}