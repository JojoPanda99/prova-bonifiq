using Microsoft.EntityFrameworkCore.Internal;
using ProvaPub.Interfaces.Repository;
using ProvaPub.Models;

namespace ProvaPub.Repository;

public class CustomerRepository: BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(TestDbContext dbContext) : base(dbContext)
    {
    }
}