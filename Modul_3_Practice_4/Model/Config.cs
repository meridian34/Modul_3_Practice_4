using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3_Practice_4.Model
{
    public class Config
    {
        public string LogFilePath { get; set; }
        public int NumberDelimeterForBackup { get; set; }
        public string BackupDirectory { get; set; }
        public string BackupNameTemplate { get; set; }
    }
}
