namespace Devtist.Image.Exif.Tag
{
    [Tag(0x011A)]
    public class ExifTagXResolution : TagExURational
    {
        public override string Name
        {
            get { return "XResolution"; }
        }
    }
}
