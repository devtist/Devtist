namespace Devtist.Image.Exif.Tag
{
    [Tag(0x010A)]
    public class ExifTagFillOrder : TagExEnum<ExifTagFillOrderType>
    {
        public override string Name
        {
            get { return "Fill order"; }
        }
    }
}
