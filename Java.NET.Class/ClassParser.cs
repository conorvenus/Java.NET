using Java.NET.Class.Constants;
using Java.NET.Class.Enums;
using Java.NET.Class.Types;

using Attribute = Java.NET.Class.Types.Attribute;

namespace Java.NET.Class
{
	public sealed class ClassParser
	{
		private const uint MAGIC_NUMBER = 0xCAFEBABE;
		private readonly string _filename;

		private BigEndianReader reader;
		private ClassFile classFile = new ClassFile();

		public ClassParser(string filename)
		{
			_filename = filename;
		}

		private List<Attribute> ParseAttributes()
		{
			List<Attribute> attributes = new List<Attribute>();
			ushort attributeCount = reader.ReadUInt16();
			for (int i = 0; i < attributeCount; i++)
			{
				ushort attributeNameIndex = reader.ReadUInt16();
				byte[] attributeBytes = reader.ReadBytes(reader.ReadUInt32());

				attributes.Add(new Attribute(((UTF8Constant)classFile.Constants[attributeNameIndex]).Value, attributeBytes));
			}
			return attributes;
		}

		private void ParseMethods()
		{
			ushort methodCount = reader.ReadUInt16();
			for (int i = 0; i < methodCount; i++)
			{
				MethodAccessFlags accessFlags = (MethodAccessFlags)reader.ReadUInt16();
				ushort nameIndex = reader.ReadUInt16();
				ushort descriptorIndex = reader.ReadUInt16();

				classFile.Methods.Add(new Method(((UTF8Constant)classFile.Constants[nameIndex]).Value, accessFlags, ((UTF8Constant)classFile.Constants[descriptorIndex]).Value, ParseAttributes().AsReadOnly()));
			}
		}

		private void ParseFields()
		{
			ushort fieldCount = reader.ReadUInt16();
			for (int i = 0; i < fieldCount; i++)
			{
				throw new NotImplementedException();
			}
		}

		private void ParseInterfaces()
		{
			ushort interfaceCount = reader.ReadUInt16();
			for (int i = 0; i < interfaceCount; i++)
			{
				throw new NotImplementedException();
			}
		}

		private void ParseConstants()
		{
			ushort constantPoolCount = reader.ReadUInt16();
			for (int i = 1; i < constantPoolCount; i++)
			{
				TagType tag = (TagType)reader.ReadByte();
				switch (tag)
				{
					case TagType.UTF_8_STRING:
						classFile.Constants.Add(new UTF8Constant(reader.ReadString(reader.ReadUInt16())));
						break;
					case TagType.INTEGER:
						classFile.Constants.Add(new IntegerConstant(unchecked((int)reader.ReadUInt32())));
						break;
					case TagType.FLOAT:
						classFile.Constants.Add(new FloatConstant(BitConverter.UInt32BitsToSingle(reader.ReadUInt32())));
						break;
					case TagType.CLASS_REFERENCE:
						classFile.Constants.Add(new ClassConstant(reader.ReadUInt16()));
						break;
					case TagType.STRING_REFERENCE:
						classFile.Constants.Add(new StringConstant(reader.ReadUInt16()));
						break;
					case TagType.METHOD_REFERENCE:
					case TagType.FIELD_REFERENCE:
					case TagType.INTERFACE_METHOD_REFERENCE:
						classFile.Constants.Add(new MethodConstant(reader.ReadUInt16(), reader.ReadUInt16()));
						break;
					case TagType.NAME_TYPE_DESCRIPTOR:
						classFile.Constants.Add(new NameTypeConstant(reader.ReadUInt16(), reader.ReadUInt16()));
						break;
					default:
						throw new NotImplementedException($"Constant pool tag type 0x{tag.ToString("X")} is not implemented.");
				}
			}
		}

		public ClassFile Parse()
		{
			reader = new BigEndianReader(File.ReadAllBytes(_filename));

			if (reader.ReadUInt32() == MAGIC_NUMBER)
			{
				classFile.MinorVersion = reader.ReadUInt16();
				classFile.MajorVersion = (JavaVersion)reader.ReadUInt16();
				ParseConstants();
				classFile.AccessFlags = (ClassAccessFlags)reader.ReadUInt16();
				classFile.SetThisClass(reader.ReadUInt16());
				classFile.SetSuperClass(reader.ReadUInt16());
				ParseInterfaces();
				ParseFields();
				ParseMethods();
				classFile.Attributes = ParseAttributes();

				return classFile;
			}
			throw new InvalidDataException("The file you provided is not a valid Java classfile.");
		}
	}
}