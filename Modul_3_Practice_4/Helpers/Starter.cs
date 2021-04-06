using Modul_3_Practice_4.Services;
using Modul_3_Practice_4.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3_Practice_4.Helpers
{
    class Starter
    {
        private readonly BackupManager _backupManager;
        public Starter()
        {
            var c = new ConfigService();
            _backupManager = new BackupManager(c.GetConfig());
        }

        public async Task Run()
        {
            Console.WriteLine("Hello World!");
            var l = await LogToFileService.Instance;
            l.BackupHandler += MakeBackup;

            if (l != null)
            {
                Task.Run(() =>
                {
                    for (int i = 0; i < 2000; i++)
                    {
                        l.LogInfoAsync(i.ToString());
                    }
                });

                Task.Run(() =>
                {
                    for (int i = 3000; i < 5000; i++)
                    {
                        l.LogInfoAsync(i.ToString());
                    }
                });

            }
        }
        public void MakeBackup()
        {
            _backupManager.MakeBackup();
        }
    }
}
