namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0101)]
    public class ExifTagImageHeight : TagExUInt
    {
        public override string Name
        {
            get { return "Image height"; }
        }
    }
}
