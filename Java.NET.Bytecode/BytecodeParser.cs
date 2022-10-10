using Java.NET.Class;
using Java.NET.Class.Types;
using Java.NET.Class.Constants;
using System.Collections.ObjectModel;

using Attribute = Java.NET.Class.Types.Attribute;

namespace Java.NET.Bytecode
{
	public class BytecodeParser
	{
		private readonly ClassFile _classFile;

		public BytecodeParser(ClassFile classFile)
		{
			_classFile = classFile;
		}

		public ReadOnlyCollection<BytecodeMethod> Parse()
		{
			List<BytecodeMethod> bytecodeMethods = new List<BytecodeMethod>();
			foreach (Method method in _classFile.Methods)
			{
				BytecodeMethod bytecodeMethod = new BytecodeMethod(method);
				Attribute codeAttribute = method.Attributes.First(attribute => attribute.Name == "Code");
				BigEndianReader reader = new BigEndianReader(codeAttribute.Bytes);

				bytecodeMethod.MaximumStackSize = reader.ReadUInt16();
				bytecodeMethod.MaximumLocalVariables = reader.ReadUInt16();

				uint codeLength = reader.ReadUInt32();
				while (codeLength > 0)
				{
					codeLength -= 1;
					Opcode opcode = (Opcode)reader.ReadByte();
					byte[] operand = new byte[] { };
					switch (opcode)
					{
						case Opcode.ICONST_M1:
						case Opcode.ALOAD_0:
						case Opcode.RETURN:
							break;
						case Opcode.LDC:
							operand = reader.ReadBytes(1);
							codeLength -= 1;
							break;
						case Opcode.INVOKESPECIAL:
						case Opcode.GETSTATIC:
						case Opcode.INVOKEVIRTUAL:
							operand = reader.ReadBytes(2);
							codeLength -= 2;
							break;
						default:
							throw new NotImplementedException($"Bytecode opcode 0x{opcode.ToString("X")} is not implemented.");
					}
					bytecodeMethod.Bytecode.Add(new Instruction(opcode, operand));
				}

				bytecodeMethods.Add(bytecodeMethod);
			}
			return bytecodeMethods.AsReadOnly();
		}
	}
}