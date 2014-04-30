namespace Devtist.Image.Exif.Tag
{
    [Tag(0x8298)]
    public class ExifTagCopyright : TagExString
    {
        public override string Name
        {
            get { return "Copyright"; }
        }
    }
}
