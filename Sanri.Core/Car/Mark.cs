namespace Sanri.Core.Car;

public class Mark
{
    public string Name { get; private set; } = null!;

    public static Mark Create(string name)
    {
        return new Mark
        {
            Name = name
        };
    }
}