using Sanri.Core.Payments;

namespace Sanri.Core.Clients;

public enum ClientPriceType
{
    Fact = 1,
    Fob = 2,
    Fob2 = 3
}

public enum ClientServiceType
{
    Entire = 1,
    Dissection = 2
}

public class Client
{
    public string FullName { get; protected set; }

    public string Username { get; protected set; }

    public string Password { get; protected set; }

    public string Country { get; private set; }

    public string Email { get; private set; }

    public string PhoneNumber { get; private set; }

    public long FobSize { get; private set; }

    public ClientServiceType Service { get; private set; }

    public ClientPriceType PriceType { get; private set; }

    public long TransportationLimit { get; private set; }

    public long Balance { get; private set; }

    public List<Payment> Payments { get; private set; }

    public Client(string fullName,
                  string username,
                  string password,
                  string country,
                  string email,
                  string phoneNumber,
                  long fobSize,
                  ClientServiceType service = ClientServiceType.Entire,
                  ClientPriceType priceType = ClientPriceType.Fact,
                  long transportationLimit = 6000)
    {
        FullName            = fullName;
        Username            = username;
        Password            = password;
        Country             = country;
        Email               = email;
        PhoneNumber         = phoneNumber;
        FobSize             = fobSize;
        Service             = service;
        PriceType           = priceType;
        TransportationLimit = transportationLimit;
        Balance             = 0;
        Payments            = new List<Payment>();
    }

    public void Replenish(PaymentAmount amount,
                          string sender,
                          string comment,
                          PaymentTransaction transaction,
                          PaymentPurpose purpose)
    {
        var payment = Payment.Create(user: this,
                                     action: PaymentAction.Replenishment,
                                     date: DateTime.Now,
                                     amount: amount,
                                     sender: sender,
                                     comment: comment,
                                     transaction: transaction,
                                     purpose: purpose);

        Payments.Add(payment);
    }

    public void Withdraw(PaymentAmount amount,
                         string sender,
                         string comment,
                         PaymentTransaction transaction,
                         PaymentPurpose purpose)
    {
        var payment = Payment.Create(user: this,
                                     action: PaymentAction.Withdrawal,
                                     date: DateTime.Now,
                                     amount: amount,
                                     sender: sender,
                                     comment: comment,
                                     transaction: transaction,
                                     purpose: purpose);

        Payments.Add(payment);
    }
}