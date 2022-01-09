using Sanri.Core.Clients;

namespace Sanri.Core.Payments;

public class Payment
{
    public Client User { get; private set; } = null!;

    public DateTime Date { get; private set; }

    public PaymentSum Sum { get; private set; }

    public string Sender { get; private set; } = null!;

    public string Comment { get; private set; } = null!;

    public PaymentTransaction Transaction { get; private set; }

    public PaymentAction Action { get; private set; }

    public PaymentPurpose Purpose { get; private set; } = null!;

    public static Payment Create(Client user,
                                 DateTime date,
                                 PaymentSum sum,
                                 string sender,
                                 string comment,
                                 PaymentTransaction transaction,
                                 PaymentAction action,
                                 PaymentPurpose purpose)
    {
        var payment = new Payment
        {
            User = user,
            Date = date,
            Sum  = sum,
            Sender      = sender,
            Comment     = comment,
            Transaction = transaction,
            Action      = action,
            Purpose     = purpose,
        };

        return payment;
    }
}