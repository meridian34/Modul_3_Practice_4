using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Modul_3_Practice_4.Model;
using Modul_3_Practice_4.Model.Enum;
using Modul_3_Practice_4.Services.Abstract;

namespace Modul_3_Practice_4.Services
{
    public class LogToFileService : ILoggerService
    {
        private static readonly Task<LogToFileService> _instance;
        private readonly IFileService _fileService;
        private readonly SemaphoreSlim _slim;
        private readonly StreamWriter _stream;
        private readonly int _numberDelimeterForBackup;
        private int _indexerForBackup;

        static LogToFileService()
        {
            _instance = CreateService();
        }

        private LogToFileService(Config config)
        {
            _slim = new SemaphoreSlim(1);
            _fileService = new FileService();
            _stream = _fileService.CreateStreamForWrite(config.LogFilePath);
            _numberDelimeterForBackup = config.NumberDelimeterForBackup;
        }

        public event Action BackupHandler;

        public static Task<LogToFileService> Instance
        {
            get { return _instance; }
        }

        public async Task LogAsync(LogType logType, string message)
        {
            await _slim.WaitAsync();
            _indexerForBackup++;
            await _fileService.WriteAsync(_stream, $"{DateTime.UtcNow}: {logType}: {message}");
            if (_indexerForBackup % _numberDelimeterForBackup == 0 && BackupHandler != null)
            {
                await _fileService.WriteAsync(_stream, $"Start Backup");
                BackupHandler.Invoke();
            }

            _slim.Release();
        }

        public async Task LogErrorAsync(string message)
        {
            await LogAsync(LogType.Error, message);
        }

        public async Task LogInfoAsync(string message)
        {
            await LogAsync(LogType.Info, message);
        }

        public async Task LogWarningAsync(string message)
        {
            await LogAsync(LogType.Warning, message);
        }

        private static async Task<LogToFileService> CreateService()
        {
            var log = await Task.Run(() =>
            {
                var c = new ConfigService();
                return new LogToFileService(c.GetConfig());
            });
            return log;
        }
    }
}
