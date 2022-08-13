using Microsoft.Extensions.Logging;


namespace HttpQuery.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogIfDebug(this ILogger logger, string message)
        {
            if(logger.IsEnabled(LogLevel.Debug))
                logger.LogDebug(message);
        }
        public static void LogIfError(this ILogger logger, string message)
        {
            if (logger.IsEnabled(LogLevel.Error))
                logger.LogError(message);
        }
        public static void LogIfError(this ILogger logger, Exception exception)
        {
            if (logger.IsEnabled(LogLevel.Error))
                logger.LogError(exception.Message);
        }
    }
}
