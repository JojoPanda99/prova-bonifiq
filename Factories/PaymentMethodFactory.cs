using ProvaPub.Models;

namespace ProvaPub.Factories;

public class PaymentMethodFactory
{
    public static PaymentMethodStrategy CreateInstanceStrategy(string paymentMethod)
    {
        switch (paymentMethod)
        {
            case "pix":
                return new PixPaymentMethodStrategy();
            case "creditcard":
                return new CreditCardPaymentMethodStrategy();
            case "paypal":
                return new PayPalPaymentMethodStrategy();
            default:
                throw new ArgumentException("Invalid payment method");
        }
    }
}