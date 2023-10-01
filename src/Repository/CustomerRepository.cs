using Microsoft.EntityFrameworkCore;
using ProvaPub.Interfaces.Repository;
using ProvaPub.Models;

namespace ProvaPub.Repository;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(TestDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<int> CountCustomersWithOrdersByCustomerId(int customerId)
    {
        return await DbSet.CountAsync(s => s.Id == customerId && s.Orders.Any());
    }
}