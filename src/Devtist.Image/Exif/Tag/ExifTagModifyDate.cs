namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0132)]
    public class ExifTagModifyDate : TagExDateTime
    {
        public override string Name
        {
            get { return "Modify date"; }
        }
    }
}
