using System;

namespace Sanri.Core.Payments.Internal;

public class MonthlyPayment
{
    public MonthlyPaymentType PaymentType { get; set; }

    public DateTime Date { get; set; }

    public long FromContainer { get; set; }

    public long Amount { get; set; }

    public string Comment { get; set; }
}