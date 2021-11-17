using Autofac;

namespace Sanri.Application
{
    public class CompositionRoot : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().SingleInstance();
            builder.RegisterType<CreateUserHandler>().SingleInstance();
        }
    }
}