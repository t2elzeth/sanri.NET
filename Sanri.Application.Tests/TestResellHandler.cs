using FluentAssertions;
using Sanri.Core.Car;
using Sanri.Core.Users;
using Xunit;

namespace Sanri.Application.Tests;

public class TestResellHandler
{
    [Fact]
    public void Test1()
    {
        var oldClient = new Client(balance: 0);
        var newClient = new Client(balance: 0);

        var car = new Car(owner: oldClient,
                          model: Model.Create(Mark.Create("Honda"), "accord"),
                          price: 100,
                          auctionFees: 100,
                          recycle: 100,
                          transport: 100,
                          amount: 100);
        var oldTotal = car.GetTotal();

        var command = new ResellCommand
        {
            Car       = car,
            NewClient = newClient,
            SellPrice = 200
        };


        var handler = new ResellHandler();
        handler.Handle(command);


        car.Owner.Should().Be(newClient);
        car.Price.Should().Be(command.SellPrice);
        car.GetTotal().Should().NotBe(oldTotal);
        oldClient.Balance.Should().BeGreaterThan(0);
        newClient.Balance.Should().BeLessThan(0);
    }
}