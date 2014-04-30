using System;

namespace Devtist.Image.Exif.Tag
{
    public class TagAttribute : Attribute
    {
        public ushort Id { get; private set; }

        public TagAttribute(ushort id)
        {
            Id = id;
        }
    }
}
