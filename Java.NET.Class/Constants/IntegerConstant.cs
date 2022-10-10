using Java.NET.Class.Enums;

namespace Java.NET.Class.Constants
{
	internal class IntegerConstant : ConstantBase
	{
		public int Value { get; }

		public IntegerConstant(int value)
		{
			Tag = TagType.INTEGER;
			Value = value;
		}
	}
}
