using ProvaPub.Factories;
using ProvaPub.Interfaces.Services;
using ProvaPub.Models;
using ProvaPub.Strategies.PaymentMethod;

namespace ProvaPub.Services;

public class OrderService : IOrderService
{
	public async Task<Order> PayOrderAsync(string paymentMethod, decimal paymentValue, int customerId)
	{
		var paymentMethodStrategy = PaymentMethodFactory.CreateInstanceStrategy(paymentMethod);
		var paymentContext = new PaymentContext(paymentMethodStrategy);
		paymentContext.payOrder();
			
		return await Task.FromResult( new Order()
		{
			Value = paymentValue
		});
	}
}