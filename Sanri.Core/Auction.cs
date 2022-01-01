namespace Sanri.Core;

public class AuctionParking
{
    public long First { get; set; }

    public long Second { get; set; }

    public long Third { get; set; }

    public long Fourth { get; set; }
}

public class Auction
{
    public string Name { get; set; }

    public AuctionParking Parking { get; set; }
}