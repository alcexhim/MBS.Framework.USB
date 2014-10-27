using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibUSB.Legacy
{
	public enum DeviceClass
	{
		PerInterface = 0,
		Audio = 1,
		Communication = 2,
		HumanInterface = 3,
		Printer = 7,
		PeerToPeer = 6,
		MassStorage = 8,
		Hub = 9,
		Data = 10,
		VendorSpecified = 0xFF
	}
}
