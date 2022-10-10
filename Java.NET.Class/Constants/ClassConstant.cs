using Java.NET.Class.Enums;

namespace Java.NET.Class.Constants
{
	internal class ClassConstant : ConstantBase
	{
		public ushort NameIndex { get; }

		public ClassConstant(ushort nameIndex)
		{
			Tag = TagType.CLASS_REFERENCE;
			NameIndex = nameIndex;
		}
	}
}
