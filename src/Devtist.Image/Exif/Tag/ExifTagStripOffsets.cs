using Devtist.Io;

namespace Devtist.Image.Exif.Tag
{
    //TODO: review this tag. Maybe should be not uint but something else
    [Tag(0x0111)]
    public class ExifTagStripOffsets : TagExUInt
    {
        public override string Name
        {
            get { return "Strip offsets"; }
        }

        public override bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit, int ifdNumber)
        {
            if ((info.Count != 1) || (ifdNumber < 0 || ifdNumber > 2))
                return base.Resolve(info, imageStream, bit, ifdNumber);
            return false;
        }
    }
}
