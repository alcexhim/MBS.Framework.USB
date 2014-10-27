using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibUSB.Legacy
{
	public abstract class Descriptor
	{
		public class DescriptorCollection
			: System.Collections.ObjectModel.Collection<Descriptor>
		{

		}
	}
}
