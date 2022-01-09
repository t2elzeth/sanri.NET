using Sanri.Core.Clients;
using Sanri.Core.InternalPayments;
using Sanri.Core.Payments;

namespace Sanri.Core.Car;

public class CarResell
{
    public Client OldClient { get; private set; } = null!;

    public Client NewClient { get; private set; } = null!;

    public Car Car { get; private set; } = null!;

    public long StartingPrice { get; private set; }

    public long SalePrice { get; private set; }

    public long Income { get; private set; }

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

        resell.BuildIncome();

        resell.OldClient.Replenish(jpySum: car.GetTotal(),
                                   sender: "CarOrder",
                                   comment: "Comment",
                                   transaction: PaymentTransaction.Cashless,
                                   purpose: PaymentPurpose.CarResell);

        resell.NewClient.Withdraw(jpySum: car.GetTotal(),
                                  sender: "CarOrder",
                                  comment: "Comment",
                                  transaction: PaymentTransaction.Cashless,
                                  purpose: PaymentPurpose.CarResell);

        if (resell.OldClient != Clients.Sanri.Instance) return resell;

        var incomeType = IncomeType.Create("CarResale");
        var income = InternalPayments.Income.Create(incomeType: incomeType,
                                                    date: DateTime.Now,
                                                    amount: resell.Income,
                                                    comment: "For resell of car");

        return resell;
    }

    private void BuildIncome()
    {
        Income = SalePrice - StartingPrice;
    }
}