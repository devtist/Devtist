namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0100)]
    public class ExifTagImageWidth : TagExUInt
    {
        public override string Name
        {
            get { return "Image width"; }
        }
    }
}
