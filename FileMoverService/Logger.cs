
using System.Diagnostics;
using System.IO;
using System;

namespace FileMoverService
{
    public static class Logger
    {
        private static string logPath = @"C:\FileMoverServiceLogs\log.txt";
        public static void LogEvent(string message)
        {
            //if (!EventLog.SourceExists("FileMoverServiceSource"))
            //{
            //    EventLog.CreateEventSource("FileMoverServiceSource", "Application");
            //}
            //EventLog.WriteEntry("FileMoverServiceSource", message);

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
