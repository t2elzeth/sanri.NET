namespace Sanri.Core;

public class AuctionParking
{
    public long First { get; private init; }

    public long Second { get; private init; }

    public long Third { get; private init; }

    public long Fourth { get; private init; }

    public static AuctionParking Create(long first,
                                        long second,
                                        long third,
                                        long fourth)
    {
        var auctionParking = new AuctionParking
        {
            First = first,
            Second = second,   
            Third = third,
            Fourth = fourth
        };

        return auctionParking;
    }
}

public class Auction
{
    public string Name { get; private init; } = null!;

    public AuctionParking Parking { get; private init; } = null!;

    public static Auction Create(string name, AuctionParking parking)
    {
        var auction = new Auction
        {
            Name = name,
            Parking = parking
        };

        return auction; 
    }
}