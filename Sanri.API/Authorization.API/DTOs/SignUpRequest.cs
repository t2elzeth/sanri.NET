using FluentValidation;
using NHibernate;
using Sanri.API.Validation.CustomValidators;

namespace Sanri.API.Authorization.API.DTOs
{
    public class SignUpRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public class Validator : AbstractValidator<SignUpRequest>
        {
            public Validator(ISessionFactory sessionFactory)
            {
                RuleFor(x => x.Username)
                    .NotEmpty()
                    .NotNull();

                RuleFor(x => x.Username).MustBeUniqueUsername(sessionFactory);

                RuleFor(x => x.Password)
                    .NotEmpty()
                    .NotNull();

                RuleFor(x => x.ConfirmPassword)
                    .Equal(x => x.Password)
                    .WithMessage("Passwords must match");
            }
        }
    }
}