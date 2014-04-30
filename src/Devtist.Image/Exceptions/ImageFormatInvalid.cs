using System;

namespace Devtist.Image.Exceptions
{
    public class ImageFormatInvalid : Exception
    {
        public ImageFormatInvalid()
            : base("Could not read image file as specified format")
        { }
    }
}
