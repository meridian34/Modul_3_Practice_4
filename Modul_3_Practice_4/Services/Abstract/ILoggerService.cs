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
        public event Action BackupHandler;
        public Task LogAsync(LogType logType, string message);
        public Task LogInfoAsync(string message);
        public Task LogWarningAsync(string message);
        public Task LogErrorAsync(string message);
    }
}
