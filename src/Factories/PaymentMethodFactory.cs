using ProvaPub.Models;
using ProvaPub.Strategies.PaymentMethod;

namespace ProvaPub.Factories;

public class PaymentMethodFactory
{
    public static PaymentMethodStrategy CreateInstanceStrategy(string paymentMethod)
    {
        switch (paymentMethod.ToUpper())
        {
            case "PIX":
                return new PixPaymentMethodStrategy();
            case "CREDITCARD":
                return new CreditCardPaymentMethodStrategy();
            case "PAYPAL":
                return new PayPalPaymentMethodStrategy();
            default:
                throw new ArgumentException("Invalid payment method");
        }
    }
}