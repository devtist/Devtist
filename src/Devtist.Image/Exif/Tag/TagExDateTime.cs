using System;
using System.Globalization;
using System.Text;
using Devtist.Io;

namespace Devtist.Image.Exif.Tag
{
    public abstract class TagExDateTime : TagEx<DateTime>
    {
        public override DateTime Value { get; protected set; }

        protected virtual string DateFormat
        {
            get { return "yyyy:MM:dd hh:mm:ss"; }
        }

        public override bool Resolve(TagInfo info, IIoStream imageStream, BitConvert bit)
        {
            var buffer = new byte[info.Count-1];
            imageStream.Read(buffer, buffer.Length, info.ValuePointer);
            var v = Encoding.ASCII.GetString(buffer);
            DateTime vd;
            if (DateTime.TryParseExact(v, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out vd))
                Value = vd;
            return true;
        }
    }
}
