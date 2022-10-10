using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Java.NET.Class.Enums
{
	[Flags]
	public enum MethodAccessFlags : ushort
	{
		ACC_PUBLIC = 0x1,
		ACC_PRIVATE = 0x2,
		ACC_PROTECTED = 0x4,
		ACC_STATIC = 0x8,
		ACC_FINAL = 0x10,
		ACC_SYNCHRONIZED = 0x20,
		ACC_BRIDGE = 0x40,
		ACC_VARARGS = 0x80,
		ACC_NATIVE = 0x100,
		ACC_ABSTRACT = 0x400,
		ACC_STRICT = 0x800,
		ACC_SYNTHETIC = 0x1000
	}

	[Flags]
	public enum ClassAccessFlags : ushort
	{
		ACC_PUBLIC = 0x1,
		ACC_FINAL = 0x10,
		ACC_SUPER = 0x20,
		ACC_INTERFACE = 0x200,
		ACC_ABSTRACT = 0x400,
		ACC_SYNTHETIC = 0x1000,
		ACC_ANNOTATION = 0x2000,
		ACC_ENUM = 0x4000
	}
}
