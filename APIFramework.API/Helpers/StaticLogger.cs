using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace APIFramework.API.Helpers
{
    public class StaticLoggerHelper { }

    public static class StaticLogger
    {
        public static ILogger<StaticLoggerHelper> Logger { get; set; }
        public static void Initialize(this ILogger<StaticLoggerHelper> logger)
        {
            Logger = logger;
        }
    } 
}
