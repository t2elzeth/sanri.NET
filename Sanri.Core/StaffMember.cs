using System;

namespace Sanri.Core;

public class StaffMember
{
    public string FullName { get; set; }

    public string Position { get; set; }

    public string Visa { get; set; }

    public DateOnly VisaExpirationDate { get; set; }
}