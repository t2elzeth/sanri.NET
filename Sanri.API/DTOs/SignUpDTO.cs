using FluentValidation;

namespace Sanri.API.DTOs
{
    public class SignUpDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public class Validator : AbstractValidator<SignUpDTO>
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