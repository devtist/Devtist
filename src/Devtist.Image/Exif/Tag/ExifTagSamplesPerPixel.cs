namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0115)]
    public class ExifTagSamplesPerPixel : TagExUInt
    {
        public override string Name
        {
            get { return "Samples per pixel"; }
        }
    }
}
