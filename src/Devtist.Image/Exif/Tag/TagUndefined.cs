using Devtist.Io;

namespace Devtist.Image.Exif.Tag
{
    public class TagUndefined : Tag
    {
        public TagUndefined(TagInfo info)
        {
            _value = info.ToString();
        }

        public override string Name
        {
            get { return "Undefined tag"; }
        }

        protected override string ValueAsString
        {
            get { return _value; }
        }

        public override bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit, int ifdNumber)
        {
            return false;
        }

        public override bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit)
        {
            return false;
        }

        private readonly string _value;
    }
}
