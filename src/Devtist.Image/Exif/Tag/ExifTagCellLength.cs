namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0109)]
    public class ExifTagCellLength : TagExUInt
    {
        public override string Name
        {
            get { return "Cell length"; }
        }
    }
}
