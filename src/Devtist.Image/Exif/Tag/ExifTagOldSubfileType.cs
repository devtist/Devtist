namespace Devtist.Image.Exif.Tag
{
    [Tag(0x00ff)]
    public class ExifTagOldSubfileType : TagExEnum<ExifTagOldSubfileTypeType>
    {
        public override string Name
        {
            get { return "Old subfile type"; }
        }
    }
}
