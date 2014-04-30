using System;

namespace Devtist.Image.Exceptions
{
    public class ImageExtensionUndefined : Exception
    {
        public ImageExtensionUndefined()
            : base("Could not determine image file extension")
        { }
    }
}
