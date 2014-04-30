namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0103)]
    public class ExifTagCompression : TagExEnum<ExifTagCompressionType>
    {
        public override string Name
        {
            get { return "Compression"; }
        }
    }
}
