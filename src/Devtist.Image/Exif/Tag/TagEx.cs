using Devtist.Io;

namespace Devtist.Image.Exif.Tag
{
    public abstract class TagEx<T> : Tag
    {
        public abstract T Value { get; protected set; }

        protected override string ValueAsString
        {
            get { return Value.ToString(); }
        }

        public override bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit, int ifdNumber)
        {
            return Resolve(info, imageStream, bit);
        }
    }
}
