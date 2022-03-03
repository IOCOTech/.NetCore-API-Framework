using Microsoft.Extensions.Configuration;

namespace APIFramework.API.Configuration
{
    internal class AppSettings : Interfaces.API.IAppSettings
    {
        private IConfiguration Config { get; }
        public AppSettings(IConfiguration config)
        {
            Config = config;
            ApplicationMonitoringKey = Config.GetValue<string>("corsOriginsAllowed");
            Config.Bind("Authentication", Authentication);
            //Config.Bind("EFCosmosConfig", EfCosmosDBSettings);
            //Config.Bind("RapidAPISettings", RapidAPISettings);
        }
        public string ApplicationMonitoringKey { get; private set; } = string.Empty;

        public Models.AppSettings.Authentication Authentication { get; private set; } = new();
    }
}
