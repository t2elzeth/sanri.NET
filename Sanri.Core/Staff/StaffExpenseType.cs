namespace Sanri.Core.Staff;

public class StaffExpenseType
{
    public string Name { get; set; }

    public static StaffExpenseType Create(string name)
    {
        var expenseType = new StaffExpenseType
        {
            Name = name
        };

        return expenseType;
    }
}