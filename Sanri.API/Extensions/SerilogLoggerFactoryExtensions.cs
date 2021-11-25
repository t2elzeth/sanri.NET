using Serilog;
using Serilog.Exceptions;

namespace Sanri.API.Extensions
{
    public static class SerilogLoggerFactoryExtensions
    {
        public static LoggerConfiguration WithDefaults(this LoggerConfiguration cfg)
        {
            return cfg.Enrich.WithExceptionDetails()
                      .Enrich.WithMachineName();
        }
    }
}