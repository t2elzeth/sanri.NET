using Sanri.Core.Clients;

namespace Sanri.Core.Car;

public class CarTotal
{
    public long Value { get; private set; }

    public ClientPriceType OwnerPriceType { get; set; }

    public long Common { get; private set; }

    public long Fob { get; private set; }

    public long Fob2 { get; private set; }

    public static CarTotal Create(Car car)
    {
        var price10           = Convert.ToInt64(car.Price * 0.1);
        var includedTransport = GetIncludedTransport(car.Transport, car.Owner.TransportationLimit);

        var total = new CarTotal
        {
            Common         = car.Price + price10 + car.AuctionFees + car.Recycle + car.Transport,
            Fob            = car.Price + car.Amount + car.Fob + includedTransport,
            Fob2           = car.Price + car.AuctionFees + car.Fob + includedTransport,
            OwnerPriceType = car.Owner.PriceType
        };
        
        total.BuildValue();

        return total;
    }

    public static long GetIncludedTransport(long transport, long transportLimit)
    {
        return transport > transportLimit ? transport : 0;
    }

    private void BuildValue()
    {
        Value = OwnerPriceType switch
        {
            ClientPriceType.Fact => Common,
            ClientPriceType.Fob => Fob,
            ClientPriceType.Fob2 => Fob2,
            _ => 0
        };
    }
}