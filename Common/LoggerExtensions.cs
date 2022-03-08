
using Serilog;
using Serilog.Formatting.Json;
using System.IO;
using System.Runtime.CompilerServices;

namespace DatadogKubernetes
{
    public static class LoggerExtensions
    {
        public static ILogger Enrich(this ILogger logger,
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            return logger
                .ForContext("MemberName", memberName)
                .ForContext("LineNumber", sourceLineNumber);
        }

        public static ILogger ConsoleLogger()
        {
            return new LoggerConfiguration().WriteTo.Console(new JsonFormatter()).CreateLogger();
        }

        public static ILogger FileLogger()
        {
            return new LoggerConfiguration().WriteTo.File(new JsonFormatter(), $@"{Directory.GetCurrentDirectory()}\var\log\containers\application.log").CreateLogger();
        }
    }
   
}
