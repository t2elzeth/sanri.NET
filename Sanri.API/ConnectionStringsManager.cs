using System.Collections.Generic;

namespace Sanri.API
{
    public static class ConnectionStringsManager
    {
        private static readonly Dictionary<string, string> ConnectionStrings = new();

        public static string DefaultConnectionStringName { get; set; } = "Default";

        public static void Add(string key,
            string connectionString)
        {
            ConnectionStrings[key] = connectionString;
        }

        public static void ReadFromConfiguration(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            foreach (var configurationSection in configuration.GetSection("ConnectionStrings").GetChildren())
            {
                ConnectionStrings[configurationSection.Key] = configurationSection.Value;
            }
        }

        public static string Get(string connectionStringName)
        {
            if (!ConnectionStrings.TryGetValue(connectionStringName, out var connectionString))
                throw new KeyNotFoundException($"Cannot find connection string '{connectionStringName}'");

            return connectionString;
        }
    }
}