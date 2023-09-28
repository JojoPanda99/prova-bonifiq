using ProvaPub.Factories;
using ProvaPub.Models;

namespace ProvaPub.Services
{
	public class OrderService
	{
		public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
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
}
