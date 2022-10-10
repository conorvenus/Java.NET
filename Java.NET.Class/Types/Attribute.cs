using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Java.NET.Class.Types
{
	public class Attribute
	{
		public string Name { get; }
		public byte[] Bytes { get; }

		public Attribute(string name, byte[] bytes)
		{
			Name = name;
			Bytes = bytes;
		}
	}
}
