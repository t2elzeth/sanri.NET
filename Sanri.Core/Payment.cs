using System;
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

public enum PaymentPurpose
{
    CarOrder = 1,
    CarResell = 2,
    CarSell = 3
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