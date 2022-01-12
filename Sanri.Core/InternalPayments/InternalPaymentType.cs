namespace Sanri.Core.InternalPayments;

public enum InternalPaymentPurpose
{
    Monthly = 1,
    Income = 2,
    StaffExpense = 3
}

public abstract class InternalPaymentType
{
    public string Name { get; protected set; } = null!;

    public InternalPaymentPurpose Purpose { get; protected set; }
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
    public static IncomeType CarResell = IncomeType.Create("CarResell");
    
    public static IncomeType Create(string name)
    {
        return new IncomeType
        {
            Name    = name,
            Purpose = InternalPaymentPurpose.Income
        };
    }
}

public class EmployeePaymentType : InternalPaymentType
{
    public static EmployeePaymentType Create(string name)
    {
        var expenseType = new EmployeePaymentType
        {
            Name    = name,
            Purpose = InternalPaymentPurpose.StaffExpense
        };

        return expenseType;
    }
}