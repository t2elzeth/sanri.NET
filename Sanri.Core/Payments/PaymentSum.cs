namespace Sanri.Core.Payments;

public class PaymentSum
{
    public decimal Jpy { get; set; }

    public decimal Usa { get; set; }

    public decimal Rate { get; set; }

    public static PaymentSum Create(decimal jpy)
    {
        var paymentSum = new PaymentSum
        {
            Jpy  = jpy,
            Usa  = 0M,
            Rate = 0M
        };

        return paymentSum;
    }

    public static PaymentSum Create(decimal jpy,
                                    decimal usa,
                                    decimal rate)
    {
        var paymentSum = new PaymentSum
        {
            Jpy  = jpy,
            Usa  = usa,
            Rate = rate
        };

        return paymentSum;
    }
}