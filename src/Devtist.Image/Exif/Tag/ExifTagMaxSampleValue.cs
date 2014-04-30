namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0119)]
    public class ExifTagMaxSampleValue : TagExUInt
    {
        public override string Name
        {
            get { return "Max sample value"; }
        }
    }
}
