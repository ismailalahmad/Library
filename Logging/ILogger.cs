namespace Logging
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string FullName, string message);
    }
}
