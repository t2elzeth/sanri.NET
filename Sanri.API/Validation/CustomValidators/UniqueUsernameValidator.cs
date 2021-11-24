using System.Data;
using Dapper;
using FluentValidation;
using FluentValidation.Validators;
using NHibernate;

namespace Sanri.API.Validation.CustomValidators
{
    public static class UniqueUsernameValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> MustBeUniqueUsername<T>(this IRuleBuilder<T, string> ruleBuilder,
                                                                          ISessionFactory sessionFactory)
        {
            return ruleBuilder.SetValidator(new UniqueUsernameValidator<T>(sessionFactory));
        }
    }

    public class UniqueUsernameValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "UniqueUsernameValidator";

        private readonly ISessionFactory _sessionFactory;

        public UniqueUsernameValidator(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public override bool IsValid(ValidationContext<T> context, string? value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            using var session = _sessionFactory.OpenStatelessSession();

            var connection = session.Connection;

            return !IsUserExists(connection, value!);
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return SystemError.UsernameIsAlreadyTaken.Message;
        }

        private static bool IsUserExists(IDbConnection connection, string username)
        {
            const string sql = @"
                                select count(1)
                                  from public.users t
                                 where t.username = :username
                                ";

            var parameters = new
            {
                username
            };

            return connection.ExecuteScalar<long>(sql, parameters) == 1;
        }
    }
}