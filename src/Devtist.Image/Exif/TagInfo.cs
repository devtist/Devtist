using System;
using Devtist.Io;

namespace Devtist.Image.Exif
{
    public class TagInfo
    {
        public TagInfo(byte[] buffer, BitConvert bit)
        {
            TagId = bit.ToUInt16(buffer, 0);
            TagType = (TagType)(bit.ToInt16(buffer, 2));
            Count = bit.ToUInt32(buffer, 4);
            ValuePointer = bit.ToUInt32(buffer, 8);
        }

        public ushort TagId { get; private set; }
        public TagType TagType { get; private set; }
        public uint Count { get; private set; }
        public uint ValuePointer { get; private set; }

        public override string ToString()
        {
            return String.Format("{0} ({3}): count {1} with value {2}", TagId.ToString("X"), Count, ValuePointer, TagType);
        }
    }
}
