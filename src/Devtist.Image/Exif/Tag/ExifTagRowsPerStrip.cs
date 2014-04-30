namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0116)]
    public class ExifTagRowsPerStrip : TagExUInt
    {
        public override string Name
        {
            get { return "Rows per strip"; }
        }
    }
}
