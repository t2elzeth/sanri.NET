using FluentAssertions;
using Xunit;

namespace Sanri.Core.Tests;

public class CarGetTotalTests
{
    [Fact]
    public void It_should_calculate_total_for_fact_client()
    {
        var client = Client.Create(priceType: ClientPriceType.Fact);
        var car = Car.Create(owner: client,
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
        var client = Client.Create(priceType: ClientPriceType.Fob);
        var car = Car.Create(owner: client,
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
        var client = Client.Create(priceType: ClientPriceType.Fob2);
        var car = Car.Create(owner: client,
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