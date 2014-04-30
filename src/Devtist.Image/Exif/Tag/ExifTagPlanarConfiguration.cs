namespace Devtist.Image.Exif.Tag
{
    [Tag(0x011C)]
    public class ExifTagPlanarConfiguration : TagExEnum<ExifTagPlanarConfigurationType>
    {
        public override string Name
        {
            get { return "Planar configuration"; }
        }
    }
}
