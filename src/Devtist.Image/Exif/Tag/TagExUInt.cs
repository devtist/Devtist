using Devtist.Io;

namespace Devtist.Image.Exif.Tag
{
    public abstract class TagExUInt : TagEx<uint>
    {
        public override uint Value { get; protected set; }

        public override bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit)
        {
            Value = info.ValuePointer;
            return true;
        }
    }
}
