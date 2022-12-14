namespace Java.NET.Class.Enums
{
	public enum TagType : byte
	{
		UTF_8_STRING = 0x1,
		INTEGER = 0x3,
		FLOAT = 0x4,
		LONG = 0x5,
		DOUBLE = 0x6,
		CLASS_REFERENCE = 0x7,
		STRING_REFERENCE = 0x8,
		FIELD_REFERENCE = 0x9,
		METHOD_REFERENCE = 0xA,
		INTERFACE_METHOD_REFERENCE = 0xB,
		NAME_TYPE_DESCRIPTOR = 0xC,
		METHOD_HANDLE = 0xF,
		METHOD_TYPE = 0x10,
		DYNAMIC = 0x11,
		INVOKE_DYNAMIC = 0x12,
		MODULE = 0x13,
		PACKAGE = 0x14
	}
}
