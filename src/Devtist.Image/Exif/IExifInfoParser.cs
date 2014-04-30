using System;
using Devtist.Io;

namespace Devtist.Image.Exif
{
    internal interface IExifInfoParser : IDisposable
    {
        IExifMetadata Parse(IIoStream stream);
    }
}
