namespace Java.NET.Bytecode
{
	public enum Opcode : byte
	{
		ALOAD_0 = 0x2A,
		INVOKESPECIAL = 0xB7,
		RETURN = 0xB1,
		ICONST_M1 = 0x02,
		GETSTATIC = 0xB2,
		LDC = 0x12,
		INVOKEVIRTUAL = 0xB6
	}

	public class Instruction
	{
		public Opcode Opcode { get; }
		public byte[] Operand { get; }

		public Instruction(Opcode opcode, byte[] operand)
		{
			Operand = operand;
			Opcode = opcode;
		}
	}
}
