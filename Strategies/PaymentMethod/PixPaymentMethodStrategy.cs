namespace ProvaPub.Models;

public class PixPaymentMethodStrategy: PaymentMethodStrategy
{
    public override void Pay()
    {
        Console.WriteLine("Pago por Pix");
    }
}