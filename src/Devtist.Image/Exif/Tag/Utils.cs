using System;
using System.Linq;

namespace Devtist.Image.Exif.Tag
{
    internal static class Utils
    {
        public static ushort GetTagId(this Type type)
        {
            var attr = type.GetCustomAttributes(typeof(TagAttribute), false).FirstOrDefault() as TagAttribute;
            return attr == null ? (ushort)0 : attr.Id;
        }
    }
}
