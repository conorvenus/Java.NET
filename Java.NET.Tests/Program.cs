using Java.NET.Bytecode;
using Java.NET.Class;
using System.Collections.ObjectModel;

ClassParser classParser = new ClassParser("Examples/HelloWorld.class");
ClassFile classFile = classParser.Parse();
BytecodeParser bytecodeParser = new BytecodeParser(classFile);
ReadOnlyCollection<BytecodeMethod> bytecodeMethods = bytecodeParser.Parse();
foreach (BytecodeMethod method in bytecodeMethods)
{
	Console.WriteLine(method.Method.Name);
	Console.WriteLine(string.Join("\n", method.Bytecode.Select(instruction => $"{Enum.GetName(typeof(Opcode), instruction.Opcode)} [{string.Join(", ", instruction.Operand)}]")));
	Console.WriteLine();
}