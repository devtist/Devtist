using System;
using System.Collections.Generic;
using System.Linq;
using Devtist.Image.Exif.Tag;
using Devtist.Io;

namespace Devtist.Image.Exif
{
    internal class ExifMetadata : IExifMetadata
    {
        private readonly IList<ImageFileDirectory> _directories;
        private readonly IDictionary<int, IDictionary<TagInfo, Tag.Tag>> _dirCache =
            new Dictionary<int, IDictionary<TagInfo, Tag.Tag>>();
        private readonly IIoStream _imageStream;
        private readonly BitConvert _bit;

        public ExifMetadata(IEnumerable<ImageFileDirectory> imageFileDirectories, IIoStream imageStream, BitConvert bit)
        {
            _imageStream = imageStream;
            _bit = bit;
            _directories = new List<ImageFileDirectory>(imageFileDirectories);
            foreach (var tag in Tags) { }
        }

        public int DirectoriesCount { get { return _directories.Count; } }
        public T GetTag<T>() where T : Tag.Tag
        {
            return _dirCache.Values.SelectMany(x => x.Values).FirstOrDefault(x => x.GetType() == typeof(T)) as T;
        }

        public IEnumerable<Tag.Tag> GetDirectory(int number)
        {
            return _directories[number].Tags.Select(x => Resolve(x, number)).Where(x => x != null);
        }

        public IEnumerable<Tag.Tag> Tags
        {
            get
            {
                var len = _directories.Count;
                for (var i = 0; i < len; i++)
                {
                    foreach (var tag in _directories[i].Tags)
                    {
                        var t = Resolve(tag, i);
                        if (t != null)
                            yield return t;
                    }
                }
            }
        }

        private readonly static object Locker = new object();
        private readonly static IDictionary<uint, IList<Type>> Cache = new Dictionary<uint, IList<Type>>();

        static ExifMetadata()
        {
            var t = typeof (Tag.Tag);
            var types = typeof (ExifMetadata).Assembly.GetTypes()
                .Where(
                    x =>
                        !x.IsAbstract && t.IsAssignableFrom(x) &&
                        x.GetCustomAttributes(typeof (TagAttribute), false).Length > 0);
            foreach (var type in types)
            {
                var id = type.GetTagId();
                if (!Cache.ContainsKey(id))
                    Cache[id] = new List<Type>();
                Cache[id].Add(type);
            }
        }

        private Tag.Tag Resolve(TagInfo info, int directoryNumber)
        {
            Tag.Tag tag;
            IDictionary<TagInfo, Tag.Tag> cache;
            if (_dirCache.TryGetValue(directoryNumber, out cache))
            {
                if (cache.TryGetValue(info, out tag))
                    return tag;
            }
            lock (Locker)
            {
                if (!_dirCache.TryGetValue(directoryNumber, out cache))
                {
                    cache = new Dictionary<TagInfo, Tag.Tag>();
                    _dirCache[directoryNumber] = cache;
                }
                if (cache.TryGetValue(info, out tag))
                    return tag;
                if (!Cache.ContainsKey(info.TagId))
                    return new TagUndefined(info);
                foreach (var t in Cache[info.TagId])
                {
                    var instance = (Tag.Tag)Activator.CreateInstance(t);
                    if (!instance.Resolve(info, _imageStream, _bit, directoryNumber))
                        continue;
                    cache[info] = instance;
                    return instance;
                }
                return new TagUndefined(info);
            }
        }
    }
}
