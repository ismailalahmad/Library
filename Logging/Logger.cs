namespace Logging
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            StreamWriter sw = File.AppendText("C:\\from zero to hero\\.net\\C#\\homework C#\\LibraryManagement1\\Logging\\Logger.txt");
            sw.WriteLine(message);
            sw.Close();
        }

        public void Log(string FullName, string message)
        {
            Log($"{(FullName == ""? "Manager":FullName)} : {DateTime.Now} : {message}");
        }
    }
}