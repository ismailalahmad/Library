namespace Logging
{
    public sealed class Logger : ILogger
    {
        public StreamWriter sw { get; set; }
        public static Logger instace { get; set; } = new Logger();
        public Logger()
        {
            instace.sw = File.AppendText("Logger.txt");
        }

        public void Log(string message)
        {
            instace.sw.WriteLine(message);
            instace.sw.Close();
        }

        public void Log(string FullName, string message)
        {
            Log($"{(FullName == ""? "Manager":FullName)} : {DateTime.Now} : {message}");
        }
    }
}