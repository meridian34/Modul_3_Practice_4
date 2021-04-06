using System.IO;
using System.Threading.Tasks;
using Modul_3_Practice_4.Services.Abstract;

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
