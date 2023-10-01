using Bogus;
using Moq.AutoMock;
using ProvaPub.Models;
using ProvaPub.Services;

namespace ProvaPubTests.Fixtures;

[CollectionDefinition(nameof(ProductColletion))]
public class ProductColletion : ICollectionFixture<ProductTestsFixture>
{
}

public class ProductTestsFixture : IDisposable
{
    public AutoMocker Mocker;
    public ProductService ProductService;
    public List<Product> Products;

    public ProductTestsFixture()
    {
        Products = new List<Product>();
        PopulateProducts();
    }

    public ProductService GetProductService()
    {
        Mocker = new AutoMocker();
        ProductService = Mocker.CreateInstance<ProductService>();

        return ProductService;
    }

    public List<Product> GetProductListPaginated(int page, int size)
    {
        return Products.Skip(page * size).Take(size).ToList();
    }

    private void PopulateProducts()
    {
        for (int i = 0; i < 20; i++)
        {
            Products.Add(new Faker<Product>().CustomInstantiator(f => new Product
                {
                    Id = f.UniqueIndex + 1,
                    Name = f.Commerce.Product()
                })
            );
        }
    }

    public void Dispose()
    {
    }
}