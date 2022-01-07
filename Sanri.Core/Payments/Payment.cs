using System;
using Sanri.Core.Users;

namespace Sanri.Core.Payments;

public class Payment
{
    public User User { get; set; }

    public DateTime Date { get; set; }

    public long JpySum { get; set; }

    public long UsaSum { get; set; }

    public decimal Rate { get; set; }

    public string Sender { get; set; }

    public string Comment { get; set; }

    public PaymentTransaction Transaction { get; set; }

    public PaymentAction Action { get; set; }

    public PaymentPurpose Purpose { get; set; }

    public static Payment Create(User user,
                                 DateTime date,
                                 long jpySum,
                                 string sender,
                                 string comment,
                                 PaymentTransaction transaction,
                                 PaymentAction action,
                                 PaymentPurpose purpose,
                                 long usaSum,
                                 long rate)
    {
        var payment = new Payment
        {
            User        = user,
            Date        = date,
            JpySum      = jpySum,
            Sender      = sender,
            Comment     = comment,
            Transaction = transaction,
            Action      = action,
            Purpose     = purpose,
            UsaSum      = usaSum,
            Rate        = rate
        };

        return payment;
    }
}