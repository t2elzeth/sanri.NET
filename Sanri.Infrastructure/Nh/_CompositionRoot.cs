using Autofac;

namespace Sanri.Infrastructure.Nh
{
    public class CompositionRoot : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(NhSessionFactory.Instance);
        }
    }
}