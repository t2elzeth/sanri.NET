using FluentValidation;
using Sanri.API.Models;
using Sanri.API.Validation;

namespace Sanri.API.DTOs
{
    public class CreateProductDTO
    {
        public virtual string Name { get; set; }
        
        public virtual decimal Price { get; set; }

        public virtual string Password { get; set; }
        
        public virtual string ConfirmPassword { get; set; }

        public class Validator : AbstractValidator<CreateProductDTO>
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