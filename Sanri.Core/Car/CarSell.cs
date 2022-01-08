using Sanri.Core.Clients;
using Sanri.Core.Payments;

namespace Sanri.Core.Car;

public class CarSell
{
    public Client Owner { get; private set; } = null!;

    public string Auction { get; private set; } = null!;

    public Car Car { get; private set; } = null!;

    public bool Sold { get; private set; }

    public long Total { get; private set; }

    public long AuctionFees { get; private set; }

    public long SalesFees { get; private set; }

    public static CarSell Create(string auction,
                                 Car car,
                                 long auctionFees,
                                 long salesFees)
    {
        var carSell = new CarSell
        {
            Total = car.Price
                    + Convert.ToInt64(car.Price * 0.1)
                    + car.Recycle
                    - auctionFees
                    - salesFees,

            Owner       = car.Owner,
            Auction     = auction,
            Car         = car,
            Sold        = false,
            AuctionFees = auctionFees,
            SalesFees   = salesFees,
        };

        return carSell;
    }

    public void MakeSold()
    {
        Car.Owner.Replenish(date: DateTime.Now,
                            jpySum: Total,
                            sender: "CarOrder",
                            comment: "Comment",
                            transaction: PaymentTransaction.Cashless,
                            purpose: PaymentPurpose.CarSell);
    }
}