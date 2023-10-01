using ProvaPub.Models;

namespace ProvaPub.Interfaces.Services;

public interface IOrderService
{
    Task<Order> PayOrderAsync(string paymentMethod, decimal paymentValue, int customerId);
}