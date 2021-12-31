using System;

namespace Sanri.Core.Car;

public class Sell
{
    public Client Owner { get; set; }

    public string Auction { get; set; }

    public Car Car { get; set; }

    public bool Sold { get; set; }

    public long Total { get; set; }

    public long AuctionFees { get; set; }

    public long SalesFees { get; set; }

    public Sell(string auction,
                   Car car,
                   long auctionFees,
                   long salesFees,
                   bool sold = false)
    {
        Total = car.Price
                + Convert.ToInt64(car.Price * 0.1)
                + car.Recycle
                - auctionFees
                - salesFees;

        Owner       = car.Owner;
        Auction     = auction;
        Car         = car;
        Sold        = sold;
        AuctionFees = auctionFees;
        SalesFees   = salesFees;
    }
}