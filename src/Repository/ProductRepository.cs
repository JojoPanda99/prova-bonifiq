using ProvaPub.Interfaces.Repository;
using ProvaPub.Models;

namespace ProvaPub.Repository;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(TestDbContext db) : base(db)
    {
    }
}