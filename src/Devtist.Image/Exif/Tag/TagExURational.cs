using Devtist.Io;

namespace Devtist.Image.Exif.Tag
{
    public abstract class TagExURational : TagEx<decimal>
    {
        public override decimal Value { get; protected set; }

        public override bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit)
        {
            var buffer = new byte[8];
            imageStream.Read(buffer, buffer.Length, info.ValuePointer);
            Value = (decimal)bit.ToUInt32(buffer, 0) / (decimal)bit.ToUInt32(buffer, 4);
            return true;
        }
    }
}
