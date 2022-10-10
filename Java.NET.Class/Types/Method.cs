using Java.NET.Class.Enums;
using System.Collections.ObjectModel;

namespace Java.NET.Class.Types
{
    public class Method
    {
		public string Name { get; }
		public MethodAccessFlags AccessFlags { get; }
        public string Descriptor { get; }
        public ReadOnlyCollection<Attribute> Attributes { get; }

        public Method(string name, MethodAccessFlags accessFlags, string descriptor, ReadOnlyCollection<Attribute> attributes)
        {
            Name = name;
            AccessFlags = accessFlags;
            Descriptor = descriptor;
            Attributes = attributes;
        }
    }
}
