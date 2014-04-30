namespace Devtist.Image.Exif.Tag
{
    [Tag(0x010D)]
    public class ExifTagDocumentName : TagExString
    {
        public override string Name
        {
            get { return "Document name"; }
        }
    }
}
