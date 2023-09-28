namespace ProvaPub.Models;

public class PayPalPaymentMethodStrategy : PaymentMethodStrategy
{
    public override void Pay()
    {
        Console.WriteLine("Pago pelo PayPal!");
    }
}