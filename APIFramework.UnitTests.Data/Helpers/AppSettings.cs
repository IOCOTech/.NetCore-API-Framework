using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.UnitTests.Data.Helpers
{
    internal static class AppSettings
    {
        private static IConfiguration config;
        private static IConfiguration Config
        {
            get
            {
                if (config == null)
                {
                    throw new System.Exception("AppSettings has not been initialized in the data unitesting project.  Call \"AppSettings.InitializeConfig\" before using settings");
                }
                return config;
            }
            set { config = value; }
        }

        internal static void InitializeConfig()
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

            config = builder.Build();
        }

        internal static string CosmosDBName => config["EFConfig:DBName"];
        internal static string CosmosEndpoint => config["EFConfig:Endpoint"];
        internal static string CosmosPrimaryKey => config["EFConfig:PrimaryKey"];
        internal static bool SeedCosmosDBData => bool.Parse(config["SeedCosmosDBData"]);
        internal static bool UseInMemoryDatabase => bool.Parse(config["UseInMemoryDatabase"]);
    }
}
