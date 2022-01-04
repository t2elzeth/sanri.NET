namespace Sanri.Core.Car;

public class Mark
{
    public string Name { get; set; }

    public static Mark Create(string name)
    {
        return new Mark
        {
            Name = name
        };
    }
}