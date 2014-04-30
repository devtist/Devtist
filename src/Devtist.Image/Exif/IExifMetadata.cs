using System.Collections.Generic;

namespace Devtist.Image.Exif
{
    public interface IExifMetadata
    {
        int DirectoriesCount { get; }
        T GetTag<T>() where T : Tag.Tag;
        IEnumerable<Tag.Tag> GetDirectory(int number);
        IEnumerable<Tag.Tag> Tags { get; }
    }
}
