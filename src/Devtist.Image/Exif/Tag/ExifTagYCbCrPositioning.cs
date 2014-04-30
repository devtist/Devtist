namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0213)]
    public class ExifTagYCbCrPositioning : TagExEnum<ExifTagYCbCrPositioningType>
    {
        public override string Name
        {
            get { return "YCbCr positioning"; }
        }
    }
}
