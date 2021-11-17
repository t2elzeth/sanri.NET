using FluentValidation;

namespace Sanri.API.Authorization.API.DTOs
{
    public class SignUpRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public class Validator : AbstractValidator<SignUpRequest>
        {
            public Validator()
            {
                RuleFor(x => x.Username)
                    .NotEmpty()
                    .NotNull();

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