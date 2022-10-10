using Java.NET.Class.Types;

namespace Java.NET.Bytecode
{
	public class BytecodeMethod
	{
		public ushort MaximumStackSize { get; internal set; }
		public ushort MaximumLocalVariables { get; internal set; }
		public Method Method { get; internal set; }
		public List<Instruction> Bytecode { get; internal set; } = new List<Instruction>();

		public BytecodeMethod(Method method)
		{
			Method = method;
		}
	}
}
