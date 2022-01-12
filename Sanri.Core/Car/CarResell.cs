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

    public static CarResell Create(Car car,
                                   Client newClient,
                                   ISanriRepository sanriRepository,
                                   long salePrice)
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

        resell.OldClient.Replenish(amount: PaymentAmount.Create(car.GetTotal()),
                                   sender: "CarOrder",
                                   comment: "Comment",
                                   transaction: PaymentTransaction.Cashless,
                                   purpose: PaymentPurpose.CarResell);

        resell.NewClient.Withdraw(amount: PaymentAmount.Create(car.GetTotal()),
                                  sender: "CarOrder",
                                  comment: "Comment",
                                  transaction: PaymentTransaction.Cashless,
                                  purpose: PaymentPurpose.CarResell);

        var sanri = sanriRepository.Get();
        if (resell.OldClient != sanri) return resell;

        var income = InternalPayments.Income.Create(incomeType: IncomeType.CarResell,
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