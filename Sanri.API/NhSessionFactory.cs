using NHibernate;
using NHibernate.Context;
using Sanri.API.Nh;

namespace Sanri.API
{
    public static class NhSessionFactory
    {
        public static ISessionFactory Instance { get; }

        static NhSessionFactory()
        {
            Instance = new SessionFactoryBuilder()
                .CurrentSessionContext<AsyncLocalSessionContext>()
                .Use(new UserTypesConvention())
                .AddFluentMappingsFrom("Sanri.API")
                .Build();
        }
    }
}