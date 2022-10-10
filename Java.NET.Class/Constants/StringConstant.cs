using Java.NET.Class.Enums;

namespace Java.NET.Class.Constants
{
	public class StringConstant : ConstantBase
	{
		public ushort StringIndex { get; }

		public StringConstant(ushort stringIndex)
		{
			Tag = TagType.STRING_REFERENCE;
			StringIndex = stringIndex;
		}
	}
}
