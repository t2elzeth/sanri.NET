using Autofac;
using Sanri.Application.Authorization.API.Handlers;
using Sanri.Application.Authorization.API.Repositories;
using Microsoft.AspNetCore.Identity;
using Sanri.Core.Models;

namespace Sanri.Application.Authorization.API
{
    public class CompositionRoot : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().SingleInstance();
            builder.RegisterType<SignUpHandler>().SingleInstance();
            builder.RegisterType<PasswordHasher<User>>().SingleInstance();
        }
    }
}