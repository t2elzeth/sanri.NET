namespace Sanri.Core.Car;

public class Model
{
    public Mark Mark { get; set; }

    public string Name { get; set; }

    public Model(Mark mark, string name)
    {
        Mark = mark;
        Name = name;
    }
}