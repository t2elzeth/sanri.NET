namespace Sanri.Core.Car;


public class CarTotal
{
    public long Common { get; private set; }

    public long Fob { get; private set; }

    public long Fob2 { get; private set; }

    public static CarTotal Create(Car car)
    {
        var price10           = Convert.ToInt64(car.Price * 0.1);
        var includedTransport = GetIncludedTransport(car.Transport, car.Owner.TransportationLimit);

        var total = new CarTotal
        {
            Common = car.Price + price10 + car.AuctionFees + car.Recycle + car.Transport,
            Fob    = car.Price + car.Amount + car.Fob + includedTransport,
            Fob2   = car.Price + car.AuctionFees + car.Fob + includedTransport,
        };

        return total;
    }

    public static long GetIncludedTransport(long transport, long transportLimit)
    {
        return transport > transportLimit ? transport : 0;
    }
}