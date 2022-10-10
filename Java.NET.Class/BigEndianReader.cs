using System.Text;

namespace Java.NET.Class
{
	internal sealed class BigEndianReader
	{
		private readonly byte[] _bytes;
		private int _offset = 0;

		public BigEndianReader(byte[] bytes)
		{
			_bytes = bytes;
		}

		public byte ReadByte() => _bytes[_offset++];

		public ushort ReadUInt16() => (ushort)((ReadByte() << 8) + ReadByte());

		public uint ReadUInt32() => (uint)((ReadByte() << 24) + (ReadByte() << 16) + (ReadByte() << 8) + ReadByte());

		public byte[] ReadBytes(uint length)
		{
			byte[] bytes = new byte[length];
			for (int i = 0; i < length; i++)
			{
				bytes[i] = ReadByte();
			}
			return bytes;
		}

		public string ReadString(uint length) => Encoding.UTF8.GetString(ReadBytes(length));
	}
}
