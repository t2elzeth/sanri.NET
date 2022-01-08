namespace Sanri.Core.Car;

public class Model
{
    public Mark Mark { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public static Model Create(Mark mark, string name)
    {
        return new Model
        {
            Mark = mark,
            Name = name
        };
    }
}