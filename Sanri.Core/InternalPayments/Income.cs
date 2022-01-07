using System;

namespace Sanri.Core.Payments.Internal;

public class Income
{
    public IncomeType PaymentType { get; set; }

    public DateTime Date { get; set; }

    public long Amount { get; set; }

    public string Comment { get; set; }
}