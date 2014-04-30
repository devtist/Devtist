using Devtist.Io;

namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0111)]
    public class ExifTagPreviewImageStart : TagExUInt
    {
        public override string Name
        {
            get { return "Preview image start"; }
        }

        public override bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit, int ifdNumber)
        {
            if (info.Count == 1 && (ifdNumber == 0 || ifdNumber == 1))
                return base.Resolve(info, imageStream, bit, ifdNumber);
            return false;
        }
    }
}
