using System.Text;
using Devtist.Io;

namespace Devtist.Image.Exif.Tag
{
    public abstract class TagExString : TagEx<string>
    {
        public override string Value { get; protected set; }

        public override bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit)
        {
            var buffer = new byte[info.Count-1];
            imageStream.Read(buffer, buffer.Length, info.ValuePointer);
            Value = Encoding.ASCII.GetString(buffer);
            return true;
        }
    }
}
