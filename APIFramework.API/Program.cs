using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace APIFramework.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Set hosting environment using environmental variable 'ASPNETCORE_ENVIRONMENT'
                    var env = context.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    // Specify the following environmental variables to use azure vault 'AZURE_CLIENT_ID' 'AZURE_CLIENT_SECRET' 'AZURE_TENANT_ID'
                    //var credentials = new DefaultAzureCredential();
                    //var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
                    //config.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
