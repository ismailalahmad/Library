namespace Logging
{
    public sealed class Logger : ILogger
    {
        public void Log(string message)
        {
            StreamWriter sw = File.AppendText("LibraryManagement1\\LibraryManagement1\\Data\\Logger.txt");
            sw.WriteLine(message);
            sw.Close();
        }

        public void Log(string FullName, string message)
        {
            Log($"{(FullName == ""? "Manager":FullName)} : {DateTime.Now} : {message}");
        }
    }
}