using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibUSB.Legacy.Descriptors
{
	public class HumanInterfaceDeviceDescriptor : Descriptor
	{
		private ushort mvarBCDHID = 0;
		public ushort BCDHID { get { return mvarBCDHID; } set { mvarBCDHID = value; } }

		private byte mvarCountryCode = 0;
		public byte CountryCode { get { return mvarCountryCode; } set { mvarCountryCode = value; } }

		private Descriptor.DescriptorCollection mvarDescriptors = new Descriptor.DescriptorCollection();
		public Descriptor.DescriptorCollection Descriptors { get { return mvarDescriptors; } }
	}
}
