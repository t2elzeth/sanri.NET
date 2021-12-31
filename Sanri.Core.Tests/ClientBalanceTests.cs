using FluentAssertions;
using Xunit;

namespace Sanri.Core.Tests;

public class ClientBalanceTests
{
    [Fact]
    public void It_should_withdraw_if_enough()
    {
        var client = new Client(balance: 20);

        client.WithdrawBalance(10);

        client.Balance.Should().Be(10);
    }

    [Fact]
    public void It_should_withdraw_if_not_enough()
    {
        var client = new Client(balance: 20);

        client.WithdrawBalance(30);

        client.Balance.Should().Be(-10);
    }

    [Fact]
    public void It_should_replenish()
    {
        var client = new Client(balance: 20);

        client.ReplenishBalance(10);

        client.Balance.Should().Be(30);
    }
}