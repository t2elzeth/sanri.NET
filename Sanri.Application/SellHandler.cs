using Sanri.Core.Car;

namespace Sanri.Application;

public class SellCommand
{
    public Car Car { get; set; }

    public string Auction { get; set; }

    public long AuctionFees { get; set; }

    public long SalesFees { get; set; }

    public bool Sold { get; set; } = false;
}

public class SellHandler
{
    public CarSell Handle(SellCommand command)
    {
        var car = command.Car;

        var carSell = car.Sell(auction: command.Auction,
                               auctionFees: command.AuctionFees,
                               salesFees: command.SalesFees,
                               sold: command.Sold);

        car.Owner.ReplenishBalance(carSell.Total);

        return carSell;
    }
}