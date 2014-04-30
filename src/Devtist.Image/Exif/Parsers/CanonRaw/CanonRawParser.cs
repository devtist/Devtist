using System;
using System.Collections.Generic;
using Devtist.Image.Exceptions;
using Devtist.Io;

namespace Devtist.Image.Exif.Parsers.CanonRaw
{
    internal class CanonRawParser : IExifInfoParser
    {
        private BitConvert _bit;
        private uint _tiffOffset;
        private uint _rawIFDOffset;
        private Version _cr2Version;
        private readonly IList<ImageFileDirectory> _ifds = new List<ImageFileDirectory>();

        public void Dispose()
        { }

        public IExifMetadata Parse(IIoStream imageStream)
        {
            ReadHeader(imageStream);
            ReadIfds(imageStream, _tiffOffset);
            return new ExifMetadata(_ifds, imageStream, _bit);
        }

        private void ReadIfds(IIoStream stream, uint ifdOffset)
        {
            var ptr = ifdOffset;
            while (ptr > 0)
            {
                var ifd = new ImageFileDirectory(ptr);
                _ifds.Add(ifd);
                var buffer = new byte[12];
                stream.Read(buffer, 2, ptr);
                var offset = ptr + 2;
                var size = _bit.ToInt16(buffer, 0);
                for (var i = 0; i < size; i++)
                {
                    var currOffset = offset + i * 12;
                    stream.Read(buffer, 12, currOffset);
                    ifd.AddTag(buffer, _bit, stream);
                }
                stream.Read(buffer, 4, offset + size * 12);
                ptr = _bit.ToUInt32(buffer, 0);
            }
        }

        private void ReadHeader(IIoStream stream)
        {
            var header = new byte[16];
            stream.Read(header, header.Length, 0);
            if ((char)header[0] == 'I' && (char)header[1] == 'I')
                _bit = new BitConvert(true);
            else if ((char)header[0] == 'M' && (char)header[1] == 'M')
                _bit = new BitConvert(false);
            else
                throw new ImageFormatInvalid();
            if (_bit.ToInt16(header, 0x0002) != 0x002a)
                throw new ImageFormatInvalid();
            _tiffOffset = _bit.ToUInt32(header, 0x0004);
            if ((char)header[0x0008] != 'C' || (char)header[0x0009] != 'R')
                throw new ImageFormatInvalid();
            _cr2Version = new Version(header[0x000a], header[0x000b]);
            _rawIFDOffset = _bit.ToUInt32(header, 0x000c);
        }
    }
}
