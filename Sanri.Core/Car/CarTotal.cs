using System;
using CSharpFunctionalExtensions;

namespace Sanri.Core.Car;

public class CarTotal : ValueObject<CarTotal>
{
    public long Common { get; set; }

    public long Fob { get; set; }

    public long Fob2 { get; set; }

    public CarTotal(long price,
                    long auctionFees,
                    long recycle,
                    long transport,
                    long amount,
                    long fob,
                    long transportationLimit)
    {
        var price10           = Convert.ToInt64(price * 0.1);
        var includedTransport = GetIncludedTransport(transport, transportationLimit);

        Common = price + price10 + auctionFees + recycle + transport;
        Fob    = price + amount + fob + includedTransport;
        Fob2   = price + auctionFees + fob + includedTransport;
    }

    public static long GetIncludedTransport(long transport, long transportLimit)
    {
        return transport > transportLimit ? transport : 0;
    }

    protected override bool EqualsCore(CarTotal other)
    {
        return Common == other.Common
               && Fob == other.Fob
               && Fob2 == other.Fob2;
    }

    protected override int GetHashCodeCore()
    {
        return Common.GetHashCode();
    }
}