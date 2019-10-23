using BobManager.Helpers.Logger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace BobManager.Helpers.Loggers
{
    public class FileLogger : ILogger
    {
        public List<LoggingFile> Files { get; private set; } = new List<LoggingFile>();
        public bool IsIssetFile(string path, out LoggingFile file)
        {
            string fullPath = Path.GetFullPath(path);
            if (!File.Exists(fullPath))
                throw new ArgumentException("File doesn't exists!", "path");
            file = Files.FirstOrDefault((x) => x.FullPath == fullPath);
            return file != null;
        }
        public bool IsIssetFile(string path)
        {
            LoggingFile outFile;
            return IsIssetFile(path, out outFile);
        }
        public bool AddFile(LoggingFile file)
        { 
            if (file == null)
                throw new ArgumentException("File can't be null", "file");
            LoggingFile outFile;
            if (!IsIssetFile(file.FullPath, out outFile))
            {
                Files.Add(file);
                return true;
            }
            else return outFile.AddLogLevels(file.LogLevels.ToArray());
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == LogLevel.Trace;
            return true;
        }
        public void Log<TState>(LogLevel logLevel, 
                                EventId eventId, 
                                TState state, 
                                Exception exception,
                                Func<TState, Exception, string> formatter
                                )
        {
            //if (formatter == null || formatter.Target == null)
            //    formatter = StringExtensions.ExceptionFormatter;
            string text = formatter(state, exception) + Environment.NewLine;
            foreach (var item in Files)
                if (item.IsIssetLogLevel(logLevel))
                    item.AppendAllText(text);
        }
    }
}