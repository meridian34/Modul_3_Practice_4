using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul_3_Practice_4.Model.Enum;
using Modul_3_Practice_4.Services.Abstract;

namespace Modul_3_Practice_4.Services
{
    public class LogToFileService : ILoggerService
    {
        private static readonly Lazy<LogToFileService> _instance;
        private LogToFileService()
        {
        }

        static LogToFileService()
        {
            _instance = new Lazy<LogToFileService>(new LogToFileService());
        }

        public LogToFileService Instance
        {
            get { return _instance.Value; }
        }


        public void Log(LogType logType, string message)
        {
            var logMessage = $"{DateTime.UtcNow}: {logType}: {message}";
            _fileService.Write(logMessage, _logConfig);
        }

        public void LogError(string message)
        {
            Log(LogType.Error, message);
        }

        public void LogInfo(string message)
        {
            Log(LogType.Info, message);
        }

        public void LogWarning(string message)
        {
            Log(LogType.Warning, message);
        }
    }
}
