using Sanri.Core.Users;

namespace Sanri.Core.Car;

public class CarResell
{
    public Client OldClient { get; set; }

    public Client NewClient { get; set; }

    public Car Car { get; set; }

    public long StartingPrice { get; set; }

    public long SalePrice { get; set; }

    public static CarResell Create(Car car, Client newClient, long salePrice)
    {
        var resell = new CarResell
        {
            OldClient     = car.Owner,
            NewClient     = newClient,
            Car           = car,
            StartingPrice = car.Price,
            SalePrice     = salePrice,
        };

        return resell;
    }
}