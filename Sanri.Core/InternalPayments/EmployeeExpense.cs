using System;

namespace Sanri.Core.InternalPayments;

public class EmployeeExpense
{
    public Employee Member { get;  private set; } = null!;

    public EmployeeExpenseType ExpenseType { get;  private set; } = null!;

    public DateOnly Date { get;  private set; }

    public long Amount { get;  private set; }

    public string Comment { get;  private set; } = null!;
}