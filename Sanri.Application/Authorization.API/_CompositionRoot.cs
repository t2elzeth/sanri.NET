using Autofac;
using Sanri.Application.Authorization.API.Handlers;
using Sanri.Application.Authorization.API.Repositories;

namespace Sanri.Application.Authorization.API
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