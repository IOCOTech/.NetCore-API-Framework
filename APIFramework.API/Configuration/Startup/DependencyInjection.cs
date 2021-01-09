
using Microsoft.Extensions.DependencyInjection;

namespace APIFramework.API.Configuration.Startup
{
    internal static class DependencyInjection
    {
        internal static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            if (AppSettings.UseMockdata)
            {
                services.AddTransient<Interfaces.Business.Users.IUser, Mock.Business.Users.User>();
            }
            else
            {

                services.AddTransient<Interfaces.Business.Users.IUser, Business.Users.User>();
                services.AddTransient<Interfaces.Data.Users.IUser, Data.Users.User>();
            }
        }
    }
}
