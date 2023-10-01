using Microsoft.EntityFrameworkCore;
using ProvaPub.Interfaces.Repository;
using ProvaPub.Models;

namespace ProvaPub.Repository;

public class OrderRepository: BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(TestDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<int> CountOrdersInMonthByCustomerIdAsync(int customerId, DateTime date)
    {
        return await DbSet.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= date);
    }
}