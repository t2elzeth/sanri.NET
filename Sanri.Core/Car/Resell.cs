using Sanri.Core.Users;

namespace Sanri.Core.Car;

public class Resell
{
    public Client OldClient { get; set; }

    public Client NewClient { get; set; }

    public Car Car { get; set; }

    public long StartingPrice { get; set; }

    public long SalePrice { get; set; }

    public Resell(Car car, Client newClient, long salePrice)
    {
        OldClient     = car.Owner;
        NewClient     = newClient;
        Car           = car;
        StartingPrice = car.Price;
        SalePrice     = salePrice;
    }
}