using ProvaPub.Models;

namespace ProvaPub.Interfaces.Repository;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<int> CountOrdersInMonthByCustomerIdAsync(int customerId, DateTime date);
}