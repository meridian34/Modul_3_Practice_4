using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul_3_Practice_4.Model.Enum;

namespace Modul_3_Practice_4.Services.Abstract
{
    public interface ILoggerService
    {
        public void Log(LogType logType, string message);
        public void LogInfo(string message);
        public void LogWarning(string message);
        public void LogError(string message);
    }
}
