using System.Text;
using Devtist.Io;

namespace Devtist.Image.Exif.Tag
{
    [Tag(0x0102)]
    public class ExifTagBitsPerSample : TagEx<ushort[]>
    {
        public override string Name
        {
            get { return "Bits per sample"; }
        }

        public override bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit)
        {
            var r = new ushort[info.Count];
            var buffer = new byte[info.Count*2];
            imageStream.Read(buffer, buffer.Length, info.ValuePointer);
            for (var i = 0; i < info.Count; i++)
                r[i] = bit.ToUInt16(buffer, i*2);
            Value = r;
            return true;
        }

        public override ushort[] Value { get; protected set; }

        protected override string ValueAsString
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append('[');
                foreach (var s in Value)
                {
                    if (sb.Length > 1)
                        sb.Append(',');
                    sb.Append(s);
                }
                sb.Append(']');
                return sb.ToString();
            }
        }
    }
}
