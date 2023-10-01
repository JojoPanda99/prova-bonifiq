using FluentAssertions;
using Moq;
using ProvaPub.Interfaces.Repository;
using ProvaPub.Models;
using ProvaPub.Services;
using ProvaPubTests.Fixtures;

namespace ProvaPubTests.Services;

[Collection(nameof(CustomerColletion))]
public class CustomerServiceSuccessTests
{
    private readonly CustomerTestsFixture _customerTestsFixture;
    private CustomerService _customerService;
    private readonly Customer _customer;

    public CustomerServiceSuccessTests(CustomerTestsFixture customerTestsFixture)
    {
        _customerTestsFixture = customerTestsFixture;
        _customerService = _customerTestsFixture.GetCustomerService();
        _customer = _customerTestsFixture.GenerateCustomer();
        _customerTestsFixture.Mocker.GetMock<ICustomerRepository>()
            .Setup(repo => repo.FindByIdAsync(_customer.Id))
            .ReturnsAsync(_customer);
    }


    [Fact(DisplayName = "Customer CanPurchase Success")]
    public async Task CanPurchase_CustomerCanPurchase_ShouldReturnTrue()
    {
        // Arrange
        decimal purchaseValue = new Random().Next(1, 100);

        // Act
        var result = await _customerService.CanPurchaseAsync(_customer.Id, purchaseValue);

        // Assert
        Assert.True(result);
    }

    [Fact(DisplayName = "Customer already has Order and return false")]
    public async Task CanPurchase_CustomerCanPurchaseSingleTimePerMonth_ShouldReturnFalse()
    {
        // Arrange
        var purchaseValue = new Random().Next(1, 100);
        _customerTestsFixture.Mocker.GetMock<IOrderRepository>()
            .Setup(repo => repo.CountOrdersInMonthByCustomerIdAsync(_customer.Id, It.IsAny<DateTime>()))
            .ReturnsAsync(1);

        // Act
        var result = await _customerService.CanPurchaseAsync(_customer.Id, purchaseValue);

        // Assert
        Assert.False(result);
    }

    [Fact(DisplayName = "Customer first buy purchaseValue greater than 100 and return false")]
    public async Task CanPurchase_CustomerFirstBuyPurchaseValueCannotBeGreaterThanOneHundred_ShouldReturnFalse()
    {
        // Arrange
        var purchaseValue = new Random().Next(101, 1000);
        _customerTestsFixture.Mocker.GetMock<ICustomerRepository>()
            .Setup(repo => repo.CountCustomersWithOrdersByCustomerId(_customer.Id))
            .ReturnsAsync(0);

        // Act
        var result = await _customerService.CanPurchaseAsync(_customer.Id, purchaseValue);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task ListProductsAsync_GetProductsPaginated()
    {
        // Arrange
        var size = 10;
        var firstPage = _customerTestsFixture.GetCustomerListPaginated(0, size);
        var secondPage = _customerTestsFixture.GetCustomerListPaginated(1, size);

        _customerTestsFixture.Mocker.GetMock<ICustomerRepository>()
            .Setup(pr => pr.GetAllPaginatedAsync(0, size))
            .ReturnsAsync(firstPage);
        _customerTestsFixture.Mocker.GetMock<ICustomerRepository>()
            .Setup(pr => pr.GetAllPaginatedAsync(1, size))
            .ReturnsAsync(secondPage);
        _customerTestsFixture.Mocker.GetMock<ICustomerRepository>()
            .Setup(pr => pr.CountAsync())
            .ReturnsAsync(_customerTestsFixture.Customers.Count());

        // Act
        var firstPageResult = await _customerService.ListCustomersAsync(0);
        var secondPageResult = await _customerService.ListCustomersAsync((1));

        // Assert
        firstPageResult.Should().NotBeEquivalentTo(secondPageResult);
    }
}