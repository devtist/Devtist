namespace Devtist.Image.Exif.Tag
{
    [Tag(0x010f)]
    public class ExifTagMake : TagExString
    {
        public override string Name
        {
            get { return "Make"; }
        }
    }
}
