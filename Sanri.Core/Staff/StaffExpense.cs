using System;

namespace Sanri.Core.Staff;

public class StaffExpense
{
    public StaffMember Member { get; set; }

    public StaffExpenseType ExpenseType { get; set; }

    public DateOnly Date { get; set; }

    public long Amount { get; set; }

    public string Comment { get; set; }
}