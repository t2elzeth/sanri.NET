using System.Data;
using Dapper;
using FluentValidation;
using FluentValidation.Validators;
using NHibernate;

namespace Sanri.API.Validation
{
    public static class UniqueLoginValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> MustBeUniqueLogin<T>(this IRuleBuilder<T, string> ruleBuilder,
                                                                          ISessionFactory sessionFactory)
        {
            return ruleBuilder.SetValidator(new UniqueLoginValidator<T>(sessionFactory));
        }
    }

    public class UniqueLoginValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "UniqueLoginValidator";

        private readonly ISessionFactory _sessionFactory;

        public UniqueLoginValidator(ISessionFactory sessionFactory)
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
            return "unique err";
            //todo return SystemError.LoginIsAlreadyUsed.Message;
        }
        
        private static bool IsUserExists(IDbConnection connection, string login)
        {
            const string sql = @"
select count(1)
  from public.users t
 where t.login = :login
";

            var parameters = new
            {
                login
            };

            return connection.ExecuteScalar<long>(sql, parameters) == 1;
        }
    }
}