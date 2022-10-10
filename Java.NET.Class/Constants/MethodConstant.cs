using Java.NET.Class.Enums;

namespace Java.NET.Class.Constants
{
	internal class MethodConstant : ConstantBase
	{
		public ushort ClassIndex { get; }
		public ushort NameTypeIndex { get; }

		public MethodConstant(ushort classIndex, ushort nameTypeIndex)
		{
			Tag = TagType.METHOD_REFERENCE;
			ClassIndex = classIndex;
			NameTypeIndex = nameTypeIndex;
		}
	}
}
