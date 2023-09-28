namespace ProvaPub.Models;

public class PaymentContext
{
    private PaymentMethodStrategy PaymentMethodStrategy { get; set; }

    public PaymentContext(PaymentMethodStrategy paymentMethodStrategy)
    {
        PaymentMethodStrategy = paymentMethodStrategy;
    }

    public void payOrder()
    {
        PaymentMethodStrategy.Pay();
    }
}