using NHibernate;
using NHibernate.Context;

namespace Sanri
{
    public static class NhSessionFactory
    {
        public static ISessionFactory Instance { get; }

        static NhSessionFactory()
        {
            Instance = new SessionFactoryBuilder()
                .CurrentSessionContext<AsyncLocalSessionContext>()
                .AddFluentMappingsFrom("Sanri")
                .Build();
        }
    }
}