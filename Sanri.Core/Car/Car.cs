using Sanri.Core.Users;

namespace Sanri.Core.Car;

public class Car
{
    public Client Owner { get; private set; }

    public Auction Auction { get; set; }

    public long LotNumber { get; set; }
    
    public Model Model { get; set; }

    public string Vin  { get; set; }

    public long Price { get; set; }

    public long AuctionFees { get; set; }

    public long Recycle { get; set; }

    public long Transport { get; set; }

    public long Amount { get; set; }

    public long Fob { get; set; }

    public TransportCompany TransportCompany { get; set; }

    public CarNumberStatus NumberStatus { get; set; }

    public bool DocumentsGiven { get; set; }

    public string Comment { get; set; }

    public long AdditionalExpenses { get; set; }

    public CarTotal Total { get; set; }

    public Car(Client owner,
               Model model,
               long price,
               long auctionFees,
               long recycle,
               long transport,
               long amount,
               long fob)
    {
        Owner       = owner;
        Model       = model;
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

    public Resell Resell(Client newClient, long sellPrice)
    {
        var oldClient = Owner;

        var carResell = new Resell(car: this,
                                   newClient: newClient,
                                   salePrice: sellPrice);

        oldClient.ReplenishBalance(GetTotal());
        newClient.WithdrawBalance(GetTotal());

        Owner = newClient;
        Price = sellPrice;

        return carResell;
    }

    public Sell Sell(string auction,
                     long auctionFees,
                     long salesFees,
                     bool sold = false)
    {
        var carSell = new Sell(car: this,
                               auction: auction,
                               auctionFees: auctionFees,
                               salesFees: salesFees,
                               sold: sold);

        this.Owner.ReplenishBalance(carSell.Total);

        return carSell;
    }
}

public enum CarNumberStatus
{
    Removed = 1,
    NotRemoved = 2,
    NotGiven = 3
}