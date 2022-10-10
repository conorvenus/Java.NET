using Java.NET.Class.Enums;

namespace Java.NET.Class.Constants
{
	internal class UTF8Constant : ConstantBase
	{
		public string Value { get; }

		public UTF8Constant(string value)
		{
			Tag = TagType.UTF_8_STRING;
			Value = value;
		}
	}
}
