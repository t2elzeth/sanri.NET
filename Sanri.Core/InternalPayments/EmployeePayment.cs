namespace Sanri.Core.InternalPayments;

public class EmployeePayment
{
    public Employee Member { get; private set; } = null!;

    public EmployeePaymentType PaymentType { get; private set; } = null!;

    public DateOnly Date { get; private set; }

    public long Amount { get; private set; }

    public string Comment { get; private set; } = null!;
}