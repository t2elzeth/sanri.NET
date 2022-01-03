using System;

namespace Sanri.Core;

public class IncomeType
{
    public string Name { get; set; }

    public static IncomeType Create(string name)
    {
        var monthlyPaymentType = new IncomeType
        {
            Name = name
        };

        return monthlyPaymentType;
    }
}

public class Income
{
    public IncomeType PaymentType { get; set; }

    public DateTime Date { get; set; }

    public long Amount { get; set; }

    public string Comment { get; set; }
}