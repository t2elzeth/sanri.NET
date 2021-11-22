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
            // TODO: Create new composition roots for repositories and handlers
            
            // Repositories
            builder.RegisterType<UserRepository>().SingleInstance();
            
            // Handlers
            builder.RegisterType<SignUpHandler>().SingleInstance();
            builder.RegisterType<SignInHandler>().SingleInstance();
            
            // Other
            builder.RegisterType<PasswordHasher<User>>().SingleInstance();
        }
    }
}