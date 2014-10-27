using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibUSB.Legacy.Descriptors
{
	public class StringDescriptor
	{
		private string mvarValue = String.Empty;
		public string Value { get { return mvarValue; } set { mvarValue = value; } }
	}
}
