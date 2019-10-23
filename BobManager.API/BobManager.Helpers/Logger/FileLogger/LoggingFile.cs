using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace BobManager.Helpers.Logger
{
    public class LoggingFile
    {
        public string FullPath { get; private set; }
        public List<LogLevel> LogLevels { get; private set; } = new List<LogLevel>();
        public object _lock { get; private set; } = new object();

        public LoggingFile(string path)
        {
            if (!SetPath(path))
            {
                File.Create(Path.GetFullPath(path));
                if (!SetPath(path))
                    throw new ArgumentException("File doesn't exists!", "path");
            }
        }

        public LoggingFile(string path, LogLevel logLevel) : this(path)
        {
            if (!AddLogLevel(logLevel))
                throw new ArgumentException("This type logging doesn't exists or logLevel already added!", "logLevel");
        }

        public LoggingFile(string path, LogLevel[] logLevels) : this(path)
        {
            if (!AddLogLevels(logLevels))
                throw new ArgumentException("This type logging doesn't exists or logLevel already added!", "logLevels");
        }

        public bool SetPath(string newPath)
        {
            string fullPath = Path.GetFullPath(newPath);
            if (!File.Exists(fullPath))
                return false;
            FullPath = fullPath;
            return true;
        }

        public bool AddLogLevel(LogLevel logLevel)
        {
            if (Enum.IsDefined(typeof(LogLevel), logLevel) &&
                !IsIssetLogLevel(logLevel))
            {
                LogLevels.Add(logLevel);
                return true;
            }
            return false;
        }

        public bool AddLogLevels(LogLevel[] logLevels)
        {
            foreach (var item in logLevels)
                if (Enum.IsDefined(typeof(LogLevel), item) &&
                    !IsIssetLogLevel(item))
                    return false;
            LogLevels.AddRange(logLevels);
            return true;
        }

        public bool RemoveLogLevel(LogLevel logLevel)
        {
            if (IsIssetLogLevel(logLevel))
            {
                LogLevels.Remove(logLevel);
                return true;
            }
            return false;
        }

        public bool IsIssetLogLevel(LogLevel logLevel)
        {
            return LogLevels.Exists((x) => x == logLevel);
        }

        public void AppendAllText(string text)
        {
            lock (_lock)
            {
                File.AppendAllText(FullPath, text);
            }
        }
    }
}