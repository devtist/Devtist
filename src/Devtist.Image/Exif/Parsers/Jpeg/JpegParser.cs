using System;
using System.Collections.Generic;
using System.Linq;
using Devtist.Image.Exceptions;
using Devtist.Io;

namespace Devtist.Image.Exif.Parsers.Jpeg
{
    internal class JpegParser : IExifInfoParser
    {
        private BitConvert _bit = new BitConvert(false);
        private uint _tiffOffset;
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
            while (ptr > 0 && ptr < stream.Length)
            {
                try
                {
                    var ifd = new ImageFileDirectory(ptr);
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
                    if (ifd.Tags.Any())
                        _ifds.Add(ifd);
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        private static readonly byte[] HeaderMarker1 = {0xFF, 0xD8};
        private static readonly byte[] HeaderMarker2 = {0xFF, 0xE1};

        private void ReadHeader(IIoStream stream)
        {
            var marker = new byte[2];
            stream.Read(marker, marker.Length, 0);
            if (!marker.SequenceEqual(HeaderMarker1))
                throw new ImageFormatInvalid();
            stream.Read(marker, marker.Length, 2);
            while (true)
            {
                if (marker.SequenceEqual(HeaderMarker2))
                    break;
                try
                {
                    stream.Read(marker, marker.Length);
                }
                catch (Exception)
                {
                    throw new ImageFormatInvalid();
                }
            }
            stream.Read(marker, marker.Length);
            var app0 = _bit.ToUInt16(marker, 0);

            var header = new byte[8];
            stream.Read(header, 6);
            var p = stream.Position;
            stream.Read(header, header.Length);
            if ((char)header[0] == 'I' && (char)header[1] == 'I')
                _bit = new BitConvert(true);
            else if ((char)header[0] == 'M' && (char)header[1] == 'M')
                _bit = new BitConvert(false);
            else
                throw new ImageFormatInvalid();
            if (_bit.ToInt16(header, 0x0002) != 0x002a)
                throw new ImageFormatInvalid();
            stream.StartOffset = p;
            _tiffOffset = _bit.ToUInt32(header, 0x0004);
        }
    }
}
