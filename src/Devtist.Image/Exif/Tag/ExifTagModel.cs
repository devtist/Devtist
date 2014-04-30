namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0110)]
    public class ExifTagModel : TagExString
    {
        public override string Name
        {
            get { return "Model"; }
        }
    }
}
