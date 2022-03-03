using Microsoft.Extensions.Configuration;

namespace APIFramework.API.Configuration
{
    internal class AppSettings : Interfaces.API.IAppSettings
    {
        private IConfiguration Config { get; }
        public AppSettings(IConfiguration config)
        {
            Config = config;
            ApplicationMonitoringKey = Config.GetValue<string>("ApplicationMonitoringKey");
            AllowedOrigins = Config.GetValue<string>("AllowedOrigins");
            Config.Bind("Authentication", Authentication);
        }

        public string ApplicationMonitoringKey { get; private set; } = string.Empty;
        public string AllowedOrigins { get; private set; } = string.Empty;
        public Models.AppSettings.Authentication Authentication { get; private set; } = new();

    }
}
