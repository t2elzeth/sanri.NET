namespace Sanri.Models
{
    public class Product
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Price { get; set; }
    }
}