using System;
using Devtist.Io;

namespace Devtist.Image.Exif.Tag
{
    public abstract class TagExEnum<TEnum> : TagEx<TEnum>
        where TEnum : struct, IComparable, IConvertible, IFormattable
    {
        public override TEnum Value { get; protected set; }

        public override bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit)
        {
            Value = (TEnum)Convert.ChangeType(info.ValuePointer, Enum.GetUnderlyingType(typeof(TEnum)));
            return true;
        }
    }
}
