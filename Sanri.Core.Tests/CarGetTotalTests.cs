using FluentAssertions;
using Sanri.Core.Car;
using Sanri.Core.Users;
using Xunit;

namespace Sanri.Core.Tests;

public class CarGetTotalTests
{
    [Fact]
    public void It_should_calculate_total_for_fact_client()
    {
        var client   = new Client(priceType: ClientPriceType.Fact);
        var carMark  = new Mark("Honda");
        var carModel = new Model(carMark, "Accord");

        var car = new Car.Car(owner: client,
                              model: carModel,
                              price: 25000,
                              auctionFees: 100,
                              recycle: 1000,
                              transport: 500,
                              amount: 200,
                              fob: 65000);

        var total = car.GetTotal();

        total.Should().Be(29100);
    }

    [Fact]
    public void It_should_calculate_total_for_fob_client()
    {
        var client   = new Client(priceType: ClientPriceType.Fob);
        var carMark  = new Mark("Honda");
        var carModel = new Model(carMark, "Accord");
        var car = new Car.Car(owner: client,
                              model: carModel,
                              price: 25000,
                              auctionFees: 100,
                              recycle: 1000,
                              transport: 500,
                              amount: 200,
                              fob: 65000);

        var total = car.GetTotal();

        total.Should().Be(90200);
    }

    [Fact]
    public void It_should_calculate_total_for_fob2_client()
    {
        var client   = new Client(priceType: ClientPriceType.Fob2);
        var carMark  = new Mark("Honda");
        var carModel = new Model(carMark, "Accord");
        var car = new Car.Car(owner: client,
                              model: carModel,
                              price: 25000,
                              auctionFees: 100,
                              recycle: 1000,
                              transport: 500,
                              amount: 200,
                              fob: 65000);

        var total = car.GetTotal();

        total.Should().Be(90100);
    }
}