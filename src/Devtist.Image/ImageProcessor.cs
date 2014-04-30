using System;
using System.IO;
using Devtist.Image.Exceptions;
using Devtist.Image.Exif;
using Devtist.Image.Exif.Parsers.CanonRaw;
using Devtist.Image.Exif.Parsers.Jpeg;
using Devtist.Io;

namespace Devtist.Image
{
    public class ImageProcessor
    {
        public static IExifMetadata RetrieveMetadata(string filePath)
        {
            return RetrieveMetadata(new FileInfo(filePath));
        }

        public static IExifMetadata RetrieveMetadata(string filePath, ImageType type)
        {
            return RetrieveMetadata(new FileInfo(filePath), type);
        }

        public static IExifMetadata RetrieveMetadata(FileInfo file)
        {
            var ext = file.Extension.ToLower().Trim('.');
            if (String.CompareOrdinal(ext, "jpg") == 0 || String.CompareOrdinal(ext, "jpeg") == 0)
                return RetrieveMetadata(file, ImageType.Jpeg);
            if (String.CompareOrdinal(ext, "cr2") == 0)
                return RetrieveMetadata(file, ImageType.CanonRaw);
            throw new ImageExtensionUndefined();
        }

        public static IExifMetadata RetrieveMetadata(FileInfo filePath, ImageType type)
        {
            using (var fileStream = new FilestreamAsync(filePath.FullName))
                return RetrieveMetadata(fileStream, type);
        }

        public static IExifMetadata RetrieveMetadata(IIoStream dataStream, ImageType type)
        {
            using (var parser = ParserSelector(type))
                return parser.Parse(dataStream);
        }

        private static IExifInfoParser ParserSelector(ImageType type)
        {
            switch (type)
            {
                case ImageType.CanonRaw:
                    return new CanonRawParser();
                case ImageType.Jpeg:
                    return new JpegParser();
                default:
                    return null;
            }
        }
    }
}
