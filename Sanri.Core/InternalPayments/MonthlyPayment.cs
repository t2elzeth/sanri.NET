using Sanri.Core.Containers;

namespace Sanri.Core.InternalPayments;

public class MonthlyPayment
{
    public Container FromContainer { get; private set; } = null!;

    public MonthlyPaymentType PaymentType { get; private set; } = null!;

    public DateOnly Date { get; private set; }

    public long Amount { get; private set; }

    public string Comment { get; private set; } = null!;
}