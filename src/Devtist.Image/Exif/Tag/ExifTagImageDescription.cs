namespace Devtist.Image.Exif.Tag
{
    [Tag(0x010E)]
    public class ExifTagImageDescription : TagExString
    {
        public override string Name
        {
            get { return "Image description"; }
        }
    }
}
