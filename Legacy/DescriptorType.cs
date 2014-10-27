using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibUSB.Legacy
{
	public enum DescriptorType
	{
		Device = 0x01,
		Config = 0x02,
		String = 0x03,
		Interface = 0x04,
		Endpoint = 0x05,
		HID = 0x21,
		Report = 0x22,
		Physical = 0x23,
		Hub = 0x29
	}
}
