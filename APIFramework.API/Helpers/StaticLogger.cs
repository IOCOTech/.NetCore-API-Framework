using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace APIFramework.API.Helpers
{
    public class StaticLoggerHelper { }

    public static class StaticLogger
    {
        private static ILogger<StaticLoggerHelper>? logger;
        public static ILogger<StaticLoggerHelper> Logger
        {
            get {
                if (logger == null) throw new Exception("The initialize logger method must be called before the logger can be used");
                return logger; 
            }
            private set { logger = value; }
        }


        //public static ILogger<StaticLoggerHelper> Logger { get; set; }
        public static void Initialize(this ILogger<StaticLoggerHelper> logger)
        {
            Logger = logger;
        }
    } 
}
