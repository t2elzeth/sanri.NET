namespace Sanri.Core.Users;

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

public class Client : User
{
    public long Balance { get; private set; }

    public string Country { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public long FobSize { get; set; }

    public ClientServiceType Service { get; set; }

    public ClientPriceType PriceType { get; set; }

    public long TransportationLimit { get; set; }

    public Client(long balance = 0,
                  ClientPriceType priceType = ClientPriceType.Fact,
                  long transportationLimit = 6000)
    {
        Balance             = balance;
        PriceType           = priceType;
        TransportationLimit = transportationLimit;
    }

    public void WithdrawBalance(long amount)
    {
        Balance -= amount;
    }

    public void ReplenishBalance(long amount)
    {
        Balance += amount;
    }
}