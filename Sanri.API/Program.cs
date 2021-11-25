using System.IO;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Commons.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sanri.API.Extensions;
using Serilog;
using Serilog.Extensions.Logging;

namespace Sanri.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                          .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            SetupSerilog(configuration);
            ConnectionStringsManager.ReadFromConfiguration(configuration);

            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseConfiguration(configuration);
                    webBuilder.UseStartup<Startup>();
                })
                .Build()
                .Run();
        }

        private static void SetupSerilog(IConfiguration configuration)
        {
            var loggerConfiguration = new LoggerConfiguration()
                                      .WithDefaults()
                                      .ReadFrom.Configuration(configuration);

            Log.Logger = loggerConfiguration.CreateLogger();
        }
    }
}