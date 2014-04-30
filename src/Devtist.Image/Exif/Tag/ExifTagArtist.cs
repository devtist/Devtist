namespace Devtist.Image.Exif.Tag
{
    [Tag(0x013b)]
    public class ExifTagArtist : TagExString
    {
        public override string Name
        {
            get { return "Artist"; }
        }
    }
}
