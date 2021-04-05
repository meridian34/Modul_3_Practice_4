using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3_Practice_4.Services.Abstract
{
    public interface IFileService
    {
        public void WriteToFile(string message, string path);
        public void CopyFile(string pathFile, string path);
    }
}
