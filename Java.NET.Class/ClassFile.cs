using Java.NET.Class.Constants;
using Java.NET.Class.Enums;
using Java.NET.Class.Types;

using Attribute = Java.NET.Class.Types.Attribute;

namespace Java.NET.Class
{
	public class ClassFile
	{
		public JavaVersion MajorVersion { get; internal set; }
		public ushort MinorVersion { get; internal set; }
		public List<Method> Methods { get; internal set; } = new List<Method>();
		public List<ConstantBase> Constants { get; internal set; } = new List<ConstantBase>() { null };
		public List<Attribute> Attributes { get; internal set; } = new List<Attribute>();
		public ClassAccessFlags AccessFlags { get; internal set; }
		public string? ThisClass { get; internal set; }
		public string? SuperClass { get; internal set; }

		internal void SetThisClass(ushort thisClassIndex)
		{
			ClassConstant thisClass = (ClassConstant)Constants[thisClassIndex];
			UTF8Constant thisClassName = (UTF8Constant)Constants[thisClass.NameIndex];
			ThisClass = thisClassName.Value;
		}

		internal void SetSuperClass(ushort superClassIndex)
		{
			if (superClassIndex == 0) return;
			ClassConstant superClass = (ClassConstant)Constants[superClassIndex];
			UTF8Constant superClassName = (UTF8Constant)Constants[superClass.NameIndex];
			SuperClass = superClassName.Value;
		}
	}
}