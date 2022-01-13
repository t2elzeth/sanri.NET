using Sanri.Core.Clients;
using Sanri.Core.Payments;

namespace Sanri.Core.Containers;

public enum ContainerStatus
{
    Shipped = 1,
    GoingTo = 2
}

public abstract class ContainerWheels
{
    public long Count { get; set; }

    public decimal Amount { get; set; }
}

public class WheelRecycling : ContainerWheels
{
}

public class WheelSales : ContainerWheels
{
}

public class Container
{
    public long Id { get; set; }
    public Client Owner { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateOnly Date { get; set; }

    public long Commission { get; set; }

    public long ContainerTransportation { get; set; }

    public long PackagingMaterials { get; set; }

    public long Transport { get; set; }

    public long Loading { get; set; }

    public ContainerStatus Status { get; set; }

    public long TotalAmount { get; set; }

    public WheelSales WheelSales { get; set; } = null!;

    public WheelRecycling WheelRecycling { get; set; } = null!;

    public static Container Create(Client owner,
                                   string name,
                                   DateOnly date,
                                   long commission,
                                   long containerTransportation,
                                   long packagingMaterials,
                                   long transportation,
                                   long loading,
                                   ContainerStatus status,
                                   long totalAmount)
    {
        var container = new Container
        {
            Owner                   = owner,
            Name                    = name,
            Date                    = date,
            Commission              = commission,
            ContainerTransportation = containerTransportation,
            PackagingMaterials      = packagingMaterials,
            Transport               = transportation,
            Loading                 = loading,
            Status                  = status,
            TotalAmount             = totalAmount
        };

        if (container.Status == ContainerStatus.Shipped)
            container.Ship();

        return container;
    }

    public void Ship()
    {
        if (Status == ContainerStatus.Shipped)
            return;

        Status = ContainerStatus.Shipped;

        var paymentSum = PaymentAmount.Create(TotalAmount);
        Owner.Withdraw(amount: paymentSum,
                       sender: "ContainerShipping",
                       comment: $"For shipping container #{Id}",
                       transaction: PaymentTransaction.Cashless,
                       purpose: PaymentPurpose.CarSell);
    }
}