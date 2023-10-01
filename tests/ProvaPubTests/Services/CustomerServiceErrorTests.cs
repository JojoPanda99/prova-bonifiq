using Moq;
using ProvaPub.Interfaces.Repository;
using ProvaPub.Models;
using ProvaPub.Services;
using ProvaPubTests.Fixtures;

namespace ProvaPubTests.Services;

[Collection(nameof(CustomerColletion))]
public class CustomerServiceErrorTests
{
    private readonly CustomerTestsFixture _customerTestsFixture;
    private CustomerService _customerService;

    public CustomerServiceErrorTests(CustomerTestsFixture customerTestsFixture)
    {
        _customerTestsFixture = customerTestsFixture;
        _customerService = _customerTestsFixture.GetCustomerService();
    }

    [Theory(DisplayName = "Customer Id equals or less than zero and throw ArgumentOutOfRangeException")]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task CanPurchase_CustomerIdEqualsOrLessThanZero_ShouldThrowArgumentOutOfRangeException(
        int customerId)
    {
        // Arrange
        var purchaseValue = 100;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
            () =>
                _customerService.CanPurchaseAsync(customerId, purchaseValue)
        );
        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Theory(DisplayName = "Purchase Value less than one hundred and throw ArgumentOutOfRangeException")]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task CanPurchase_PurchaseValueLessThanZero_ShouldThrowArgumentOutOfRangeException(
        decimal purchaseValue)
    {
        // Arrange
        var customerId = 1;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
            () =>
                _customerService.CanPurchaseAsync(customerId, purchaseValue)
        );
        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Fact(DisplayName = "Return null Customer and throw InvalidOperationExeception")]
    public async Task CanPurchase_CustomerNotFound_ShouldThrowInvalidOperationExeception()
    {
        // Arrange
        var customerId = 1;
        _customerTestsFixture.Mocker.GetMock<ICustomerRepository>()
            .Setup(cr => cr.FindByIdAsync(customerId))
            .ReturnsAsync((Customer?)null);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            () => _customerService.CanPurchaseAsync(customerId, 100)
        );
        Assert.Equal($"Customer Id {customerId} does not exists", exception.Message);
        Assert.IsType<InvalidOperationException>(exception);
    }
}