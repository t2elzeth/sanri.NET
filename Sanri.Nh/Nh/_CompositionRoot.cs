using Autofac;

namespace Sanri.Nh.Nh
{
    public class CompositionRoot : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(NhSessionFactory.Instance);
        }
    }
}