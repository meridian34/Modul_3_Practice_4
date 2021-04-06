using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul_3_Practice_4.Services.Abstract;
using System.Threading;

namespace Modul_3_Practice_4.Services
{
    public class FileService : IFileService
    {
        public StreamWriter CreateStreamForWrite(string path)
        {
            return new StreamWriter(path);
        }

        public async Task WriteAsync(StreamWriter stream, string text)
        {
            await stream.WriteLineAsync(text);
            await stream.FlushAsync();
        }
    }
}
