using Commons.Nh.Contexts;
using NHibernate;
using NHibernate.Cfg;

namespace Sanri.Nh
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