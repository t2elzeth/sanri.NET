namespace Sanri.Core.InternalPayments;

public class MonthlyPayment
{
    public MonthlyPaymentType PaymentType { get; private set; } = null!;

    public DateTime Date { get; private set; }

    public long FromContainer { get; private set; }

    public long Amount { get; private set; }

    public string Comment { get; private set; } = null!;
}