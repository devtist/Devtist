using System.Collections.Generic;
using Devtist.Io;

namespace Devtist.Image.Exif
{
    public class ImageFileDirectory
    {
        public uint Offset { get; private set; }
        private readonly IDictionary<ushort, TagInfo> _ifds = new Dictionary<ushort, TagInfo>();
        public IEnumerable<TagInfo> Tags {get { return _ifds.Values; }}

        public ImageFileDirectory(uint offset)
        {
            Offset = offset;
        }

        public void AddTag(byte[] buffer, BitConvert bit, IIoStream stream)
        {
            var tag = new TagInfo(buffer, bit);
            _ifds[tag.TagId] = tag;
        }
    }
}
