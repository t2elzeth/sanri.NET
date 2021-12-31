namespace Sanri.Core;

public class Car
{
    public Client Owner { get; private set; }

    public long Price { get; set; }

    public long AuctionFees { get; set; }

    public long Recycle { get; set; }

    public long Transport { get; set; }

    public long Amount { get; set; }

    public long Fob { get; set; }

    public CarTotal Total { get; set; }

    private Car()
    {
    }

    public static Car Create(Client owner,
                             long price,
                             long auctionFees,
                             long recycle,
                             long transport,
                             long amount,
                             long fob)
    {
        var total = CarTotal.Create(price,
                                    auctionFees,
                                    recycle,
                                    transport,
                                    amount,
                                    fob,
                                    owner.TransportationLimit);
        return new Car
        {
            Owner       = owner,
            Total       = total,
            Price       = price,
            AuctionFees = auctionFees,
            Recycle     = recycle,
            Transport   = transport,
            Amount      = amount,
            Fob         = fob
        };
    }

    public long GetTotal()
    {
        return Owner.PriceType switch
        {
            ClientPriceType.Fact => Total.Common,
            ClientPriceType.Fob => Total.Fob,
            ClientPriceType.Fob2 => Total.Fob2,
            _ => 0
        };
    }

    public CarResell Resell(Client newClient, long sellPrice)
    {
        var oldClient = Owner;

        var carResell = new CarResell(car: this,
                                      newClient: newClient,
                                      salePrice: sellPrice);

        oldClient.ReplenishBalance(GetTotal());
        newClient.WithdrawBalance(GetTotal());

        Owner = newClient;
        Price = sellPrice;

        return carResell;
    }

    public CarSell Sell(string auction,
                        long auctionFees,
                        long salesFees,
                        bool sold = false)
    {
        var carSell = new CarSell(car: this,
                                  auction: auction,
                                  auctionFees: auctionFees,
                                  salesFees: salesFees,
                                  sold: sold);

        this.Owner.ReplenishBalance(carSell.Total);

        return carSell;
    }
}