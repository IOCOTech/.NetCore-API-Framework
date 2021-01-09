using Microsoft.Extensions.Configuration;

namespace APIFramework.API.Configuration
{
    internal static class AppSettings
    {
        private static IConfiguration Configuration { get; set; }
        public static void InitializeAppSettings(this IConfiguration config)
        {
            Configuration = config;
        }

        internal static class EntityFramwork
        {
            internal static bool SeedDBData => Configuration.GetValue<bool>("SeedDBData");
        }
        internal static class Authentication
        {
            internal static string Authority => Configuration.GetValue<string>("Authentication:Authority");
            internal static string AudienceIdToken => Configuration.GetValue<string>("Authentication:AudienceIdToken");
            internal static string AudienceAccessToken => Configuration.GetValue<string>("Authentication:AudienceAccessToken");
        }
        internal static bool UseMockdata => Configuration.GetValue<bool>("UseMockdata");

    }
}
