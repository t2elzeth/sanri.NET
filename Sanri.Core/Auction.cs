namespace Sanri.Core;

public class AuctionParking
{
    public long First { get; private set; }

    public long Second { get; private set; }

    public long Third { get; private set; }

    public long Fourth { get; private set; }
}

public class Auction
{
    public string Name { get; private set; } = null!;

    public AuctionParking Parking { get; private set; } = null!;
}