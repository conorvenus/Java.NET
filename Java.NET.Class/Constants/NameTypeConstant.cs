using Java.NET.Class.Enums;

namespace Java.NET.Class.Constants
{
	internal class NameTypeConstant : ConstantBase
	{
		public ushort NameIndex { get; }
		public ushort DescriptorIndex { get; }

		public NameTypeConstant(ushort nameIndex, ushort descriptorIndex)
		{
			Tag = TagType.NAME_TYPE_DESCRIPTOR;
			NameIndex = nameIndex;
			DescriptorIndex = descriptorIndex;
		}
	}
}
