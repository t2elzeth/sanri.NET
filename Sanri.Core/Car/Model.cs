namespace Sanri.Core.Car;

public class Model
{
    public Mark Mark { get; set; }

    public string Name { get; set; }

    public static Model Create(Mark mark, string name)
    {
        return new Model
        {
            Mark = mark,
            Name = name
        };
    }
}