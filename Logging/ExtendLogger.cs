namespace Logging
{
    public static class ExtendLogger
    {
        public static string FullName="";
        public static void LogOpration(this ILogger logger, string message)
        {
            logger.Log(FullName, message);
        }
    }
}
