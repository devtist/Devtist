namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0112)]
    public class ExifTagOrientation : TagExEnum<ExifTagOrientationType>
    {
        public override string Name
        {
            get { return "Orientation"; }
        }
    }
}
