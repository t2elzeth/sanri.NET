namespace Sanri.Core;

public enum ClientPriceType
{
    Fact = 1,
    Fob = 2,
    Fob2 = 3
}

public class Client
{
    public long Balance { get; private set; }

    public ClientPriceType PriceType { get; set; }

    public long TransportationLimit { get; set; }

    private Client()
    {
    }

    public static Client Create(long balance = 0,
                                ClientPriceType priceType = ClientPriceType.Fact,
                                long transportationLimit = 6000)
    {
        return new Client
        {
            Balance = balance,
            PriceType = priceType,
            TransportationLimit = transportationLimit
        };
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