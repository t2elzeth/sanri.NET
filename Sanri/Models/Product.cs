using System.ComponentModel.DataAnnotations;

namespace Sanri.Models
{
    interface IProduct
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
    
    public class Product: IProduct
    {
        public virtual long Id { get; set; }
        
        public virtual string Name { get; set; }
        
        public virtual int Price { get; set; }
    }

    public class ProductCreate
    {
        [Required]
        public virtual string Name { get; set; }
        
        [Range(0, 200)]
        public virtual int Price { get; set; }

        public virtual string Password { get; set; }
        
        [Compare("Password")]
        public virtual string ConfirmPassword { get; set; }
    }
}