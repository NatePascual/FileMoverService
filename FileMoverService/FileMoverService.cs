using System;
using System.IO;
using System.ServiceProcess;

namespace FileMoverService
{
    public partial class FileMoverService : ServiceBase
    {
        private FileSystemWatcher watcher;
        private string sourcePath = @"C:\Folder1";
        private string destinationPath = @"C:\Folder2";
        private string logPath = @"C:\FileMoverServiceLogs\log.txt";

        public FileMoverService()
        {
            InitializeComponent();

            this.CanPauseAndContinue = true;
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                Directory.CreateDirectory(sourcePath);
                Directory.CreateDirectory(destinationPath);
                Directory.CreateDirectory(Path.GetDirectoryName(logPath));

                watcher = new FileSystemWatcher(sourcePath);
                watcher.Created += OnFileCreated;
                watcher.EnableRaisingEvents = true;

                Logger.LogEvent("Service Started.");
            }
            catch (Exception ex) 
            {
                Logger.LogEvent($"Error in OnStart: {ex.Message}");
                throw;
            }

        }

        protected override void OnStop()
        {
            Logger.LogEvent("Service Stopped.");
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            string sourceFile = e.FullPath;
            string destinationFile = Path.Combine(destinationPath,Path.GetFileName(e.Name));

            try
            {
                File.Move(sourceFile, destinationFile);
               Logger.LogEvent($"Moved File: {sourceFile} to {destinationFile}");
            }
            catch (Exception ex)
            {
               Logger.LogEvent($"Error moving file: {ex.Message}");
            }

        }
    }
}
