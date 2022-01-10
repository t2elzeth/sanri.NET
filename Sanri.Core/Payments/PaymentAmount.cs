namespace Sanri.Core.Payments;

public class PaymentAmount
{
    public decimal Jpy { get; set; }

    public decimal Usa { get; set; }

    public decimal Rate { get; set; }

    public static PaymentAmount Create(decimal jpy)
    {
        var paymentSum = new PaymentAmount
        {
            Jpy  = jpy,
            Usa  = 0M,
            Rate = 0M
        };

        return paymentSum;
    }

    public static PaymentAmount Create(decimal jpy,
                                       decimal usa,
                                       decimal rate)
    {
        var paymentSum = new PaymentAmount
        {
            Jpy  = jpy,
            Usa  = usa,
            Rate = rate
        };

        return paymentSum;
    }
}