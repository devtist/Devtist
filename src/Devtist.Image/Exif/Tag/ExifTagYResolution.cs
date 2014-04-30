namespace Devtist.Image.Exif.Tag
{
    [Tag(0x011B)]
    public class ExifTagYResolution : TagExURational
    {
        public override string Name
        {
            get { return "YResolution"; }
        }
    }
}
