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

    public Car(Client owner,
               long price,
               long auctionFees,
               long recycle,
               long transport,
               long amount,
               long fob)
    {
        Owner       = owner;
        Price       = price;
        AuctionFees = auctionFees;
        Recycle     = recycle;
        Transport   = transport;
        Amount      = amount;
        Fob         = fob;

        Total = CalculateTotal();
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

    public CarTotal CalculateTotal()
    {
        return new CarTotal(price: Price,
                            auctionFees: AuctionFees,
                            recycle: Recycle,
                            transport: Transport,
                            amount: Amount,
                            fob: Fob,
                            transportationLimit: Owner.TransportationLimit);
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