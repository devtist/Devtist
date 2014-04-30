namespace Devtist.Image.Exif.Tag
{
    [Tag(0x8769)]
    public class ExifTagExifOffset : TagExUInt
    {
        public override string Name
        {
            get { return "Exif offset"; }
        }
    }
}
