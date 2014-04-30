namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0106)]
    public class ExifTagPhotometricInterpretation : TagExEnum<ExifTagPhotometricInterpretationType>
    {
        public override string Name
        {
            get { return "Photometric interpretation"; }
        }
    }
}
