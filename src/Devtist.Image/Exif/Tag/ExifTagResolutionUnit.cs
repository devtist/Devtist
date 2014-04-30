namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0128)]
    public class ExifTagResolutionUnit : TagExEnum<ExifTagResolutionUnitType>
    {
        public override string Name
        {
            get { return "Resolution unit"; }
        }
    }
}
