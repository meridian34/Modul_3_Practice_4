using System;
using System.Threading.Tasks;
using Modul_3_Practice_4.Services;

namespace Modul_3_Practice_4.Helpers
{
    public class Starter
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

            var t1 = Task.Run(async () =>
            {
                for (int i = 0; i < 2000; i++)
                {
                    await l.LogInfoAsync(i.ToString());
                }
            });

            var t2 = Task.Run(async () =>
            {
                for (int i = 3000; i < 5000; i++)
                {
                    await l.LogInfoAsync(i.ToString());
                }
            });

            await Task.WhenAll(t1, t2);
        }

        public void MakeBackup()
        {
            _backupManager.MakeBackup();
        }
    }
}
