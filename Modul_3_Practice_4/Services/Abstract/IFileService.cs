using System.IO;
using System.Threading.Tasks;

namespace Modul_3_Practice_4.Services.Abstract
{
    public interface IFileService
    {
        public StreamWriter CreateStreamForWrite(string path);

        public Task WriteAsync(StreamWriter stream, string text);
    }
}
