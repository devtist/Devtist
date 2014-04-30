namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0117)]
    public class ExifTagStripByteCounts : TagExUInt
    {
        public override string Name
        {
            get { return "Strip byte counts"; }
        }
    }
}
