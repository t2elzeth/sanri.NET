using System.ComponentModel.DataAnnotations;
using System.Data;
using FluentValidation;
using Sanri.API.Validation;

namespace Sanri.API.Models
{
    public class Product
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; } = null!;

        public virtual Price Price { get; set; } = null!;
    }

    public class ProductCreate
    {
        public virtual string Name { get; set; }
        
        public virtual decimal Price { get; set; }

        public virtual string Password { get; set; }
        
        public virtual string ConfirmPassword { get; set; }

        public class Validator : AbstractValidator<ProductCreate>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotNull()
                                    .NotEmpty();

                RuleFor(x => x.Price).MustBeValueObject(Models.Price.Create);
                
                //todo
                //RuleFor(x => x.ConfirmPassword).
            }
        }
    }
}