namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0108)]
    public class ExifTagCellWidth : TagExUInt
    {
        public override string Name
        {
            get { return "Cell width"; }
        }
    }
}
