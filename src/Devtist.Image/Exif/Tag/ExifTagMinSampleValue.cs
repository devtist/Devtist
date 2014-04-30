namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0118)]
    public class ExifTagMinSampleValue : TagExUInt
    {
        public override string Name
        {
            get { return "Min sample value"; }
        }
    }
}
