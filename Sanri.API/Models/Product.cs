namespace Sanri.API.Models
{
    public class Product
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; } = null!;

        public virtual Price Price { get; set; } = null!;
    }
}