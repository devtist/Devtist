using System;
using Devtist.Io;

namespace Devtist.Image.Exif.Tag
{
    //TODO: http://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/EXIF.html
    //      http://lclevy.free.fr/cr2/
    //      http://www.sno.phy.queensu.ca/~phil/exiftool/TagNames/Canon.html
    //      http://en.wikipedia.org/wiki/Raw_image_format
    //      http://dev.exiv2.org/projects/exiv2/wiki/The_Metadata_in_JPEG_files
    public abstract class Tag
    {
        public abstract string Name { get; }

        protected abstract string ValueAsString { get; }

        public ushort Id
        {
            get { return GetType().GetTagId(); }
        }

        public abstract bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit, int ifdNumber);
        public abstract bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit);

        public override string ToString()
        {
            return String.Format("{0}: {1}", Name, ValueAsString);
        }
    }
}
