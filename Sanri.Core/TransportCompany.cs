namespace Sanri.Core;

public class TransportCompany
{
    public string Name { get; private set; } = null!;

    public static TransportCompany Create(string name)
    {
        var transportCompany = new TransportCompany
        {
            Name = name
        };

        return transportCompany;
    }
}