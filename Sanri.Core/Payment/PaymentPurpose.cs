using CSharpFunctionalExtensions;

namespace Sanri.Core.Payment;

public class PaymentPurpose : ValueObject<PaymentPurpose>
{
    public static readonly PaymentPurpose CarOrder = new("CarOrder");
    public static readonly PaymentPurpose CarResell = new("CarResell");
    public static readonly PaymentPurpose CarSell = new("CarSell");

    public string Value { get; private set; }

    private PaymentPurpose(string purpose)
    {
        Value = purpose;
    }

    public static PaymentPurpose Create(string purpose)
    {
        return new PaymentPurpose(purpose);
    }

    protected override bool EqualsCore(PaymentPurpose other)
    {
        return Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
        return Value.GetHashCode();
    }
}