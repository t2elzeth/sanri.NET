using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace Sanri.Application.Nh
{
    public static class NhSessionFactory
    {
        public static ISessionFactory Instance { get; }

        static NhSessionFactory()
        {
            Instance = new SessionFactoryBuilder()
                .CurrentSessionContext<AsyncLocalSessionContext>()
                // .Use(new UserTypesConvention())
                .AddFluentMappingsFrom("Sanri.Application")
                .ExposeConfiguration(cfg => cfg.SetProperty(Environment.Hbm2ddlKeyWords, "none"))
                .Build();
        }
    }
}