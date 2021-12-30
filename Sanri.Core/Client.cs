namespace Sanri.Core;

public class Client
{
    public long Balance { get; private set; }

    private Client()
    {
    }

    public static Client Create(long balance = 0)
    {
        return new Client
        {
            Balance = balance
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