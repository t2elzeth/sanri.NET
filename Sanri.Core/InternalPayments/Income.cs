using System;

namespace Sanri.Core.InternalPayments;

public class Income
{
    public IncomeType PaymentType { get; private set; } = null!;

    public DateTime Date { get; private set; }

    public long Amount { get; private set; }

    public string Comment { get; private set; } = null!;

    public static Income Create(IncomeType incomeType,
                                DateTime date,
                                long amount,
                                string comment)
    {
        var income = new Income
        {
            PaymentType = incomeType,
            Date        = date,
            Amount      = amount,
            Comment     = comment
        };


        return income;
    }
}