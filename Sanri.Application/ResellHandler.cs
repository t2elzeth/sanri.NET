using Sanri.Core.Car;
using Sanri.Core.Users;

namespace Sanri.Application;

public class ResellCommand
{
    public Car Car { get; set; }

    public Client NewClient { get; set; }

    public long SellPrice { get; set; }
}

public class ResellHandler
{
    public CarResell Handle(ResellCommand command)
    {
        var car       = command.Car;
        var oldClient = car.Owner;
        var newClient = command.NewClient;

        var resell = car.Resell(newClient: newClient,
                                sellPrice: command.SellPrice);

        oldClient.ReplenishBalance(car.GetTotal());
        newClient.WithdrawBalance(car.GetTotal());

        return resell;
    }
}