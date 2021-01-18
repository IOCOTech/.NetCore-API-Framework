using APIFramework.API.Helpers;
using APIFramework.Models.Errors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using Guards;

namespace APIFramework.API.Configuration.Startup
{
    public static class ExceptionMiddlewareExtensions
    {
        private static readonly ILogger<StaticLoggerHelper> logger = StaticLogger.Logger;

        public static void ConfigureExceptionHandler(this IApplicationBuilder app) =>
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        var baseException = contextFeature.Error.GetBaseException();
                        if (baseException is ValidationException)
                        {
                            logger.LogError("Validation Error: {UserId} {ValidationErrors} {RequestBody} {Claims}",
                                new object[]
                                {
                                    GetUserId(context.User),
                                    contextFeature.Error.Message,
                                    GetRequestBodyContents(context.Request),
                                    GetClaims(context.User)
                                });
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            await context.Response.WriteAsync(new APIError()
                            {
                                StatusCode = (int)HttpStatusCode.BadRequest,
                                Message = $"Validation Error: {baseException.Message}"
                            }.ToString()).ConfigureAwait(false);


                        }
                        else if (baseException is ArgumentNullException || baseException is ArgumentException)
                        {
                            logger.LogError("Invalid Argument: {UserId} {Error} {RequestBody} {Claims}",
                                new object[]
                                {
                                    GetUserId(context.User),
                                    contextFeature.Error.Message,
                                    GetRequestBodyContents(context.Request),
                                    GetClaims(context.User)
                                });

                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            await context.Response.WriteAsync(new APIError()
                            {
                                StatusCode = (int)HttpStatusCode.BadRequest,
                                Message = $"Refer to logs"
                            }.ToString()).ConfigureAwait(false);
                        }
                        else
                        {
                            logger.LogError("Something went wrong: {UserId} {Error} {RequestBody} {Claims}",
                                new object[]
                                {
                                    GetUserId(context.User),
                                    contextFeature.Error,
                                    GetRequestBodyContents(context.Request),
                                    GetClaims(context.User)
                                });

                            await context.Response.WriteAsync(new APIError()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Refer to logs"
                            }.ToString()).ConfigureAwait(false);
                        }

                    }

                });
            });
        public static string GetClaims(ClaimsPrincipal user)
        {
            Guard.ArgumentNotNull(user, nameof(user));
            var claims = new StringBuilder();
            user.Claims.ToList().ForEach(claim => claims.Append($"{claim.Type}:{claim.Value} | "));
            return claims.ToString();
        }
        public static string GetUserId(ClaimsPrincipal user)
        {
            return user.Claims.ToList().FirstOrDefault(x => x.Type == "sub")?.Value;
        }

        public static string GetRequestBodyContents(HttpRequest Request)
        {
            try
            {
                var bodyText = "";
                using (var bodyStream = new StreamReader(Request.Body))
                {
                    bodyStream.BaseStream.Seek(0, SeekOrigin.Begin);
                    bodyText = bodyStream.ReadToEnd();
                }

                return bodyText;
            }
            catch (Exception)
            {
                //Ignore exception and return empty string.
                //Do not want to throw exception in global API Exception handler
                return string.Empty;
            }

        }
    }
}
