using ProvaPub.Dtos;
using ProvaPub.Interfaces.Repository;
using ProvaPub.Interfaces.Services;
using ProvaPub.Models;

namespace ProvaPub.Services;

public class ProductService : IProductService
{
    private const int ItemPerPage = 10;
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductsPaginatedDto> ListProductsAsync(int page)
    {
        var productsPaginated = await _productRepository
            .GetAllPaginatedAsync(page, ItemPerPage);
        var productsCount = await _productRepository.CountAsync();
        var hasNext = (productsCount / ItemPerPage) > (page + 1);

        return new ProductsPaginatedDto
        {
            HasNext = hasNext,
            TotalCount = productsCount,
            Products = productsPaginated
        };
    }
}