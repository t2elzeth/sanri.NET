using FluentValidation;
using NHibernate;
using Sanri.API.Validation.CustomValidators;

namespace Sanri.API.Authorization.API.DTOs
{
    public class SignInRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public class Validator : AbstractValidator<SignInRequest>
        {
            private readonly ISessionFactory _sessionFactory;

            public Validator(ISessionFactory sessionFactory)
            {
                _sessionFactory = sessionFactory;
                RuleFor(x => x.Username).MustUsernameExist(sessionFactory);
            }
        }
    }
}