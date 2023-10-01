using FluentAssertions;
using Moq;
using ProvaPub.Interfaces.Repository;
using ProvaPub.Services;
using ProvaPubTests.Fixtures;

namespace ProvaPubTests.Services;

[Collection(nameof(ProductColletion))]
public class ProductServiceTests
{
    private readonly ProductTestsFixture _productTestFixture;
    private readonly ProductService _productService;

    public ProductServiceTests(ProductTestsFixture productTestFixture)
    {
        _productTestFixture = productTestFixture;
        _productService = _productTestFixture.GetProductService();
    }

    [Fact]
    public async Task ListProductsAsync_GetProductsPaginated()
    {
        // Arrange
        var size = 10;
        var firstPage = _productTestFixture.GetProductListPaginated(0, size);
        var secondPage = _productTestFixture.GetProductListPaginated(1, size);

        _productTestFixture.Mocker.GetMock<IProductRepository>()
            .Setup(pr => pr.GetAllPaginatedAsync(0, size))
            .ReturnsAsync(firstPage);
        _productTestFixture.Mocker.GetMock<IProductRepository>()
            .Setup(pr => pr.GetAllPaginatedAsync(1, size))
            .ReturnsAsync(secondPage);
        _productTestFixture.Mocker.GetMock<IProductRepository>()
            .Setup(pr => pr.CountAsync())
            .ReturnsAsync(_productTestFixture.Products.Count());

        // Act
        var firstPageResult = await _productService.ListProductsAsync(0);
        var secondPageResult = await _productService.ListProductsAsync(1);

        // Assert
        firstPageResult.Should().NotBeEquivalentTo(secondPageResult);
    }
}