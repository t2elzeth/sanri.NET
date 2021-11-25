using System.Data;
using Dapper;
using FluentValidation;
using FluentValidation.Validators;
using NHibernate;
using Sanri.System;

namespace Sanri.API.Validation.CustomValidators
{
    public static class UsernameExistsValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> MustUsernameExist<T>(this IRuleBuilder<T, string> ruleBuilder,
                                                                          ISessionFactory sessionFactory)
        {
            return ruleBuilder.SetValidator(new UsernameExistsValidator<T>(sessionFactory));
        }
    }

    public class UsernameExistsValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "UsernameExistsValidator";

        private readonly ISessionFactory _sessionFactory;

        public UsernameExistsValidator(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public override bool IsValid(ValidationContext<T> context, string? value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            using var session = _sessionFactory.OpenStatelessSession();

            var connection = session.Connection;

            return IsUserExists(connection, value!);
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return SystemError.UserIsNotFoundMessage;
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