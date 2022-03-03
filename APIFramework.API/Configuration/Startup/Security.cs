using APIFramework.API.Helpers;
using APIFramework.Interfaces.API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace APIFramework.API.Configuration.Startup
{
    public static class Security
    {
        public static void SetupSecurity(this IServiceCollection services, IAppSettings settings)
        {
            services.AddAuthentication()
                .AddJwtBearer("bearer", jwtOptions =>
                {
                    jwtOptions.Authority = settings.Authentication.Authority;
                    jwtOptions.Audience = settings.Authentication.AudienceIdToken;
                    jwtOptions.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = AuthenticationFailed,
                        OnTokenValidated = AuthenticationSuccess,
                        OnMessageReceived = AuthenticationMessageReceived

                    };
                });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes("bearer")
                    .RequireRole("user")
                    .Build();

                options.AddPolicy("Administrator", new AuthorizationPolicyBuilder()
                   .RequireAuthenticatedUser()
                   .AddAuthenticationSchemes("bearer")
                   .RequireRole("admin")
                   .Build());
            });
        }

        private static Task AuthenticationFailed(AuthenticationFailedContext arg)
        {
            StaticLogger.Logger.LogInformation($"Authentication failed: {arg.Exception.Message}", (object)new object[] { arg });
            return Task.FromResult(0);
        }

        private static Task AuthenticationSuccess(TokenValidatedContext arg)
        {
            StaticLogger.Logger.LogInformation($"Authentication Success: {arg.HttpContext.Session.Id }", (object)new object[] { arg });
            return Task.FromResult(0);
        }

        private static Task AuthenticationMessageReceived(MessageReceivedContext context)
        {
            string authentication = context.Request.Headers["Authentication"];

            // If no authorization header found, nothing to process further
#pragma warning disable CA1508 // Avoid dead conditional code
            if (!string.IsNullOrEmpty(authentication))
#pragma warning restore CA1508 // Avoid dead conditional code
            {
                if (authentication.StartsWith("Token ", StringComparison.OrdinalIgnoreCase))
                {
                    context.Token = authentication["Token ".Length..].Trim();
                    //TODO: Add logging for success
                }

                return Task.CompletedTask;
            }
            context.NoResult();
            //TODO: Add logging for no header
            return Task.CompletedTask;
        }
    }
}
