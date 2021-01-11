using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFramework.API.Configuration.Startup
{
    public static class Security
    {
        public static void SetupSecurity(this IServiceCollection services)
        {
            services.AddAuthentication()
                .AddJwtBearer("bearer", jwtOptions =>
                {
                    jwtOptions.Authority = AppSettings.Authentication.Authority;
                    jwtOptions.Audience = AppSettings.Authentication.AudienceIdToken;
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
            //TODO: Add logging
            var s = $"AuthenticationFailed: {arg.Exception.Message}";
            return Task.FromResult(0);
        }

        private static Task AuthenticationSuccess(TokenValidatedContext arg)
        {
            //TODO: Add logging
            var s = $"AuthenticationSuccess for Access Token: {arg}";
            return Task.FromResult(0);
        }

        private static Task AuthenticationMessageReceived(MessageReceivedContext context)
        {
            string authentication = context.Request.Headers["Authentication"];

            // If no authorization header found, nothing to process further
            if (string.IsNullOrEmpty(authentication))
            {
                context.NoResult();
                //TODO: Add logging for no header
                return Task.CompletedTask;
            }

            if (authentication.StartsWith("Token ", StringComparison.OrdinalIgnoreCase))
            {
                context.Token = authentication.Substring("Token ".Length).Trim();
                //TODO: Add logging for success
            }

            // If no token found, no further work possible
            if (string.IsNullOrEmpty(context.Token))
            {
                context.NoResult();
                //TODO: Add logging for no token
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
