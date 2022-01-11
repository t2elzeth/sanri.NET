namespace Sanri.Core;

public class Employee
{
    public string FullName { get; private set; } = null!;

    public string Visa { get; private set; } = null!;

    public string Position { get; private set; } = null!;

    public DateOnly VisaExpirationDate { get; private set; }

    public static Employee Create(string fullName,
                                  string visa,
                                  string position,
                                  DateOnly visaExpirationDate)
    {
        var employee = new Employee
        {
            FullName = fullName,
            Visa = visa,
            Position = position,
            VisaExpirationDate = visaExpirationDate
        };

        return employee;
    }
}