using Sanri.Core.Clients;

namespace Sanri.Core.Payments;

public class Payment
{
    public Client User { get; private set; } = null!;

    public DateTime Date { get; private set; }

    public decimal JpySum { get; private set; }

    public decimal UsaSum { get; private set; }

    public decimal Rate { get; private set; }

    public string Sender { get; private set; } = null!;

    public string Comment { get; private set; } = null!;

    public PaymentTransaction Transaction { get; private set; }

    public PaymentAction Action { get; private set; }

    public PaymentPurpose Purpose { get; private set; } = null!;

    public static Payment Create(Client user,
                                 DateTime date,
                                 decimal jpySum,
                                 decimal usaSum,
                                 decimal rate,
                                 string sender,
                                 string comment,
                                 PaymentTransaction transaction,
                                 PaymentAction action,
                                 PaymentPurpose purpose)
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