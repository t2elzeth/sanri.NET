using System;

namespace Sanri.Core;

public class MonthlyPaymentType
{
    public string Name { get; set; }

    public static MonthlyPaymentType Create(string name)
    {
        var monthlyPaymentType = new MonthlyPaymentType
        {
            Name = name
        };

        return monthlyPaymentType;
    }
}

public class MonthlyPayment
{
    public MonthlyPaymentType PaymentType { get; set; }

    public DateTime Date { get; set; }

    public long FromContainer { get; set; }

    public long Amount { get; set; }

    public string Comment { get; set; }
}