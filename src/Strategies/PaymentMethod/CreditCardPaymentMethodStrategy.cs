namespace ProvaPub.Strategies.PaymentMethod;

public class CreditCardPaymentMethodStrategy: PaymentMethodStrategy
{
    public override void Pay()
    {
        Console.WriteLine("Pago por Cartao de Credito!");
    }
}