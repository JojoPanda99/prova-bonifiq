namespace ProvaPub.Strategies.PaymentMethod;

public class PayPalPaymentMethodStrategy : PaymentMethodStrategy
{
    public override void Pay()
    {
        Console.WriteLine("Pago pelo PayPal!");
    }
}