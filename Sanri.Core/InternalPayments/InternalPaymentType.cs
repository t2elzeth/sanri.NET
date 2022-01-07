namespace Sanri.Core.Payments.Internal;

public enum InternalPaymentPurpose
{
    Monthly = 1,
    Income = 2,
    StaffExpense = 3
}

public abstract class InternalPaymentType
{
    public string Name { get; set; }

    public InternalPaymentPurpose Purpose { get; set; }
}

public class MonthlyPaymentType : InternalPaymentType
{
    public static MonthlyPaymentType Create(string name)
    {
        return new MonthlyPaymentType
        {
            Name    = name,
            Purpose = InternalPaymentPurpose.Monthly
        };
    }
}

public class IncomeType : InternalPaymentType
{
    public static IncomeType Create(string name)
    {
        return new IncomeType
        {
            Name    = name,
            Purpose = InternalPaymentPurpose.Income
        };
    }
}

public class StaffExpenseType : InternalPaymentType
{
    public static StaffExpenseType Create(string name)
    {
        var expenseType = new StaffExpenseType
        {
            Name    = name,
            Purpose = InternalPaymentPurpose.StaffExpense
        };

        return expenseType;
    }
}