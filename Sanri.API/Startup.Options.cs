using Microsoft.Extensions.DependencyInjection;
using Sanri.Application.Authorization.API.Handlers;

namespace Sanri.API
{
    public partial class Startup
    {
        public void RegisterConfigurations(IServiceCollection services)
        {
            services.Configure<SignInHandlerOptions>(_configuration.GetSection("Jwt"));
            //services.AddSingleton(_configuration.GetSection("Jwt").Get<SignInHandlerOptions>());
        }
    }
}