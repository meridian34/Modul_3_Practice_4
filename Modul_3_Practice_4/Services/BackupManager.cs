using System;
using System.IO;
using Modul_3_Practice_4.Model;
using Modul_3_Practice_4.Services.Abstract;

namespace Modul_3_Practice_4.Services
{
    public class BackupManager : IBackupManager
    {
        private readonly string _fileToCopy;
        private readonly string _backupDirectory;
        private readonly string _nameTemplate;

        public BackupManager(Config config)
        {
            _fileToCopy = config.LogFilePath;
            _backupDirectory = config.BackupDirectory;
            _nameTemplate = config.BackupNameTemplate;
        }

        public void MakeBackup()
        {
            if (!Directory.Exists(_backupDirectory))
            {
                Directory.CreateDirectory(_backupDirectory);
            }

            var backupFile = $@"{_backupDirectory}\{DateTime.Now.ToString(_nameTemplate)}.txt";
            File.Copy(_fileToCopy, backupFile);
        }
    }
}
