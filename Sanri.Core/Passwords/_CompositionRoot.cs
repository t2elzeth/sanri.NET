using Autofac;

namespace Sanri.Core.Passwords
{
    public class CompositionRoot : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HashPasswordCommand>().SingleInstance();
        }
    }
}