using CSharpFunctionalExtensions;
using Sanri.Core.Clients;
using Sanri.Core.Payments;

namespace Sanri.Core.Car;

public class Car
{
    public Client Owner { get; private set; } = null!;

    public Auction Auction { get; private set; } = null!;

    public long LotNumber { get; private set; }

    public Model Model { get; private set; } = null!;

    public string Vin { get; private set; } = null!;

    public long Price { get; private set; }

    public long AuctionFees { get; private set; }

    public long Recycle { get; private set; }

    public long Transport { get; private set; }

    public long Amount { get; private set; }

    public long Fob { get; private set; }

    public TransportCompany TransportCompany { get; private set; } = null!;

    public CarNumberStatus NumberStatus { get; private set; }

    public bool DocumentsGiven { get; private set; }

    public string Comment { get; private set; } = null!;

    public long AdditionalExpenses { get; private set; }

    public CarTotal Total { get; private set; } = null!;

    public CarSell? CarSell { get; private set; }

    public List<CarResell> CarResells { get; private set; } = null!;

    public static Car Create(Client owner,
                             ISanriRepository sanriRepository,
                             Model model,
                             long price,
                             long auctionFees,
                             long recycle,
                             long transport,
                             long amount,
                             long lotNumber,
                             Auction auction,
                             string vin,
                             TransportCompany transportCompany,
                             long additionalExpenses,
                             bool documentsGiven,
                             CarNumberStatus numberStatus,
                             string comment,
                             CarTotal total)
    {
        var car = new Car
        {
            Owner              = owner,
            Model              = model,
            Price              = price,
            AuctionFees        = auctionFees,
            Recycle            = recycle,
            Transport          = transport,
            Amount             = amount,
            Auction            = auction,
            Vin                = vin,
            TransportCompany   = transportCompany,
            Comment            = comment,
            Total              = total,
            CarResells         = new List<CarResell>(),
            Fob                = owner.FobSize,
            LotNumber          = lotNumber,
            AdditionalExpenses = additionalExpenses,
            DocumentsGiven     = documentsGiven,
            NumberStatus       = numberStatus
        };

        car.BuildTotal();

        car.Owner.Withdraw(amount: PaymentAmount.Create(car.GetTotal()),
                           sender: "CarOrder",
                           comment: "Comment",
                           transaction: PaymentTransaction.Cashless,
                           purpose: PaymentPurpose.CarOrder);

        if (car.Owner.PriceType != ClientPriceType.Fob2)
            return car;

        var sanriPaymentSum = PaymentAmount.Create(car.Recycle + Convert.ToDecimal(car.Price * 0.1));
        var sanri           = sanriRepository.Get();
        sanri.Withdraw(amount: sanriPaymentSum,
                       sender: "CarOrder",
                       comment: "Comment",
                       transaction: PaymentTransaction.Cashless,
                       purpose: PaymentPurpose.CarOrder);

        return car;
    }

    public long GetTotal()
    {
        return Total.Value;
    }

    private void BuildTotal()
    {
        Total = CarTotal.Create(this);
    }

    public Result<CarResell, string> Resell(Client newClient, ISanriRepository sanriRepository, long sellPrice)
    {
        if (Owner == newClient)
            return "Client can not resell to himself";

        var carResell = CarResell.Create(car: this,
                                         sanriRepository: sanriRepository,
                                         newClient: newClient,
                                         salePrice: sellPrice);

        Owner = newClient;
        Price = sellPrice;
        BuildTotal();

        CarResells.Add(carResell);
        return carResell;
    }

    public Result<CarSell, string> MakeForSell(string auction,
                                               long auctionFees,
                                               long salesFees)
    {
        if (CarSell is not null)
            return "This car is already put for sell!";

        var carSell = CarSell.Create(car: this,
                                     auction: auction,
                                     auctionFees: auctionFees,
                                     salesFees: salesFees);

        CarSell = carSell;

        return carSell;
    }

    public Result<CarSell, string> MakeSold()
    {
        if (CarSell is null)
            return "This car was not put for sell!";

        CarSell.MakeSold();

        return CarSell;
    }
}

public enum CarNumberStatus
{
    Removed = 1,
    NotRemoved = 2,
    NotGiven = 3
}