using Java.NET.Class.Enums;

namespace Java.NET.Class.Constants
{
	internal class FloatConstant : ConstantBase
	{
		public float Value { get; }

		public FloatConstant(float value)
		{
			Tag = TagType.FLOAT;
			Value = value;
		}
	}
}
