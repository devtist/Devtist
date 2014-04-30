namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0107)]
    public class ExifTagThresholding : TagExEnum<ExifTagThresholdingType>
    {
        public override string Name
        {
            get { return "Thresholding"; }
        }
    }
}
