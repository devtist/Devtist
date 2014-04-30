using System;
using System.Linq;

namespace Devtist.Io
{
    public class BitConvert
    {
        private readonly bool _isLittleEndian;

        public BitConvert(bool isLittleEndian)
        {
            _isLittleEndian = isLittleEndian;
        }

        public short ToInt16(byte[] value, int startIndex)
        {
            return _isLittleEndian
                ? BitConverter.ToInt16(value, startIndex)
                : BitConverter.ToInt16(value.Reverse().ToArray(), value.Length - sizeof(Int16) - startIndex);
        }

        public int ToInt32(byte[] value, int startIndex)
        {
            return _isLittleEndian
                ? BitConverter.ToInt32(value, startIndex)
                : BitConverter.ToInt32(value.Reverse().ToArray(), value.Length - sizeof(Int32) - startIndex);
        }

        public long ToInt64(byte[] value, int startIndex)
        {
            return _isLittleEndian
                ? BitConverter.ToInt64(value, startIndex)
                : BitConverter.ToInt64(value.Reverse().ToArray(), value.Length - sizeof(Int64) - startIndex);
        }

        public float ToSingle(byte[] value, int startIndex)
        {
            return _isLittleEndian
                ? BitConverter.ToSingle(value, startIndex)
                : BitConverter.ToSingle(value.Reverse().ToArray(), value.Length - sizeof(Single) - startIndex);
        }

        public string ToString(byte[] value)
        {
            return BitConverter.ToString(_isLittleEndian ? value : value.Reverse().ToArray());
        }

        public string ToString(byte[] value, int startIndex)
        {
            return BitConverter.ToString(_isLittleEndian ? value : value.Reverse().ToArray(), startIndex);
        }

        public string ToString(byte[] value, int startIndex, int length)
        {
            return BitConverter.ToString(_isLittleEndian ? value : value.Reverse().ToArray(), startIndex, length);
        }

        public ushort ToUInt16(byte[] value, int startIndex)
        {
            return _isLittleEndian
                ? BitConverter.ToUInt16(value, startIndex)
                : BitConverter.ToUInt16(value.Reverse().ToArray(), value.Length - sizeof(UInt16) - startIndex);
        }

        public uint ToUInt32(byte[] value, int startIndex)
        {
            return _isLittleEndian
                ? BitConverter.ToUInt32(value, startIndex)
                : BitConverter.ToUInt32(value.Reverse().ToArray(), value.Length - sizeof(UInt32) - startIndex);
        }

        public ulong ToUInt64(byte[] value, int startIndex)
        {
            return _isLittleEndian
                ? BitConverter.ToUInt64(value, startIndex)
                : BitConverter.ToUInt64(value.Reverse().ToArray(), value.Length - sizeof(UInt64) - startIndex);
        }
    }
}
