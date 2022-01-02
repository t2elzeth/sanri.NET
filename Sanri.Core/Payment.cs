using System;
using CSharpFunctionalExtensions;
using Sanri.Core.Users;

namespace Sanri.Core;

public enum PaymentTransaction
{
    Cash = 1,
    Cashless = 2,
}

public enum PaymentAction
{
    Replenishment = 1,
    Withdrawal = 2
}

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

public class Payment
{
    public User User { get; set; }

    public DateTime Date { get; set; }

    public long JpySum { get; set; }

    public long UsaSum { get; set; }

    public decimal Rate { get; set; }

    public string Sender { get; set; }

    public string Comment { get; set; }

    public PaymentTransaction Transaction { get; set; }

    public PaymentAction Action { get; set; }

    public PaymentPurpose Purpose { get; set; }
}