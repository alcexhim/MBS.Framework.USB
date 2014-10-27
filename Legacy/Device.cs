using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibUSB.Legacy
{
	public class Device
	{
		public static Device[] GetDevices(short vendor, short product)
		{
			List<Device> list = new List<Device>();
			// TODO: return a list of all devices matching the vendor and product ID
			return list.ToArray();
		}
	}
}
