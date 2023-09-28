namespace ProvaPub.Models;

public class CreditCardPaymentMethodStrategy: PaymentMethodStrategy
{
    public override void Pay()
    {
        Console.WriteLine("Pago por Cartao de Credito!");
    }
}