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

    public long Balance { get; private set; }

    public string Country { get; private set; }

    public string Email { get; private set; }

    public string PhoneNumber { get; private set; }

    public long FobSize { get; private set; }

    public ClientServiceType Service { get; private set; }

    public ClientPriceType PriceType { get; private set; }

    public long TransportationLimit { get; private set; }

    public List<Payment> Payments { get; private set; }

    public Client(string country,
                  string email,
                  string phoneNumber,
                  string fullName,
                  string username,
                  string password,
                  long balance = 0,
                  ClientPriceType priceType = ClientPriceType.Fact,
                  long transportationLimit = 6000)
    {
        Country             = country;
        Email               = email;
        PhoneNumber         = phoneNumber;
        FullName            = fullName;
        Username            = username;
        Password            = password;
        Balance             = balance;
        PriceType           = priceType;
        TransportationLimit = transportationLimit;
        Payments            = new List<Payment>();
    }

    public void Replenish(DateTime date,
                          decimal jpySum,
                          string sender,
                          string comment,
                          PaymentTransaction transaction,
                          PaymentPurpose purpose,
                          decimal usaSum = 0M,
                          decimal rate = 0M)
    {
        var payment = Payment.Create(user: this,
                                     action: PaymentAction.Replenishment,
                                     date: date,
                                     jpySum: jpySum,
                                     sender: sender,
                                     comment: comment,
                                     transaction: transaction,
                                     purpose: purpose,
                                     usaSum: usaSum,
                                     rate: rate);

        Payments.Add(payment);
    }

    public void Withdraw(DateTime date,
                         decimal jpySum,
                         string sender,
                         string comment,
                         PaymentTransaction transaction,
                         PaymentPurpose purpose,
                         decimal usaSum = 0M,
                         decimal rate = 0M)
    {
        var payment = Payment.Create(user: this,
                                     action: PaymentAction.Withdrawal,
                                     date: date,
                                     jpySum: jpySum,
                                     usaSum: usaSum,
                                     rate: rate,
                                     sender: sender,
                                     comment: comment,
                                     transaction: transaction,
                                     purpose: purpose);

        Payments.Add(payment);
    }
}