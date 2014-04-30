using System.IO;

namespace Devtist.Io
{
    public class FilestreamAsync : IIoStream
    {
        private readonly Stream _file;

        public FilestreamAsync(string filePath, FileMode mode = FileMode.Open, FileAccess access = FileAccess.Read, FileShare share = FileShare.Read, int bufferSize = 4096)
        {
            _file = new FileStream(filePath, mode, access, share, bufferSize, FileOptions.Asynchronous);
        }

        public void Dispose()
        {
            _file.Dispose();
        }

        public async void Read(byte[] buffer, int size, long offset = -1, bool ensure = true)
        {
            if (offset >= 0)
                _file.Seek(StartOffset + offset, SeekOrigin.Begin);
            if (ensure && (await _file.ReadAsync(buffer, 0, size)) != size)
                throw new IOException("Size mismatch");
        }

        public long Length { get { return _file.Length; } }
        public long StartOffset { get; set; }
        public long Position { get { return _file.Position; } }
    }
}
