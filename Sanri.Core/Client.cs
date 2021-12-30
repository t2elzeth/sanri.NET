namespace Sanri.Core;

public enum ClientPriceTypeEnum
{
    Fact = 1,
    Fob = 2,
    Fob2 = 3
}

public class Client
{
    public long Balance { get; private set; }

    public ClientPriceTypeEnum PriceType { get; set; }

    public long TransportationLimit { get; set; }

    private Client()
    {
    }

    public static Client Create(long balance = 0,
                                ClientPriceTypeEnum priceType = ClientPriceTypeEnum.Fact,
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