namespace Devtist.Image.Exif.Tag
{
    [Tag(0x000B)]
    public class ExifTagProcessingSoftware : TagExString
    {
        public override string Name
        {
            get { return "Processing software"; }
        }
    }
}
