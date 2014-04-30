namespace Devtist.Image.Exif.Tag
{
    [Tag(0x011D)]
    public class ExifTagPageName : TagExString
    {
        public override string Name
        {
            get { return "Page name"; }
        }
    }
}
