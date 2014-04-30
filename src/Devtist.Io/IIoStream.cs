using System;

namespace Devtist.Io
{
    public interface IIoStream : IDisposable
    {
        void Read(byte[] buffer, int size, long offset = -1, bool ensure = true);
        long Length { get; }
        long StartOffset { get; set; }
        long Position { get; }
    }
}
