//
//  Context.cs
//
//  Author:
//       Mike Becker <alcexhim@gmail.com>
//
//  Copyright (c) 2019 Mike Becker
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MBS.Framework.USB
{
	public class UsbContext : IDisposable
	{
		private IntPtr mvarHandle = IntPtr.Zero;
		public IntPtr Handle { get { return mvarHandle; } }

		private DebugLevel mvarDebugLevel = DebugLevel.None;
		public DebugLevel DebugLevel
		{
			get { return mvarDebugLevel; }
			set
			{
				mvarDebugLevel = value;
				if (mvarHandle != IntPtr.Zero) {
					Internal.Methods.libusb_set_debug (mvarHandle, (int)mvarDebugLevel);
				}
			}
		}

		public UsbContext()
		{
			Internal.Constants.LibUSBError retval = Internal.Methods.libusb_init (ref mvarHandle);
		}

		public UsbDevice[] GetDevices()
		{
			List<UsbDevice> list = new List<UsbDevice> ();
			IntPtr hList = IntPtr.Zero;
			int count = Internal.Methods.libusb_get_device_list (mvarHandle, ref hList);

			IntPtr[] hDevs = new IntPtr[ count ];
			Marshal.Copy(hList, hDevs, 0, count);

			for (int i = 0; i < count; i++) {
				// IntPtr hDev = new IntPtr ((long)(hList.ToInt64 () + (IntPtr.Size * i)));
				IntPtr hDev = hDevs[i];

				Internal.Structures.DeviceDescriptor desc = new MBS.Framework.USB.Internal.Structures.DeviceDescriptor ();
				Internal.Methods.libusb_get_device_descriptor(hDev, ref desc);

				UsbDevice dev = new UsbDevice (mvarHandle, desc);
				/*
				IntPtr ptr = IntPtr.Zero;
				dev.Open ();

				dev.SetConfiguration (1);
				dev.ClaimInterface (0);

				Internal.Methods.libusb_get_string_descriptor (hDev, desc.iManufacturer, 1033, ptr, 64);

				dev.ReleaseInterface (0);
				dev.Close ();
				*/

				list.Add (dev);
			}

			Marshal.FreeHGlobal (hList);
			return list.ToArray ();
		}
		public UsbDevice[] GetDevices(ushort vendorID, ushort productID)
		{
			List<UsbDevice> list = new List<UsbDevice> ();
			UsbDevice[] devs = GetDevices ();
			foreach (UsbDevice dev in devs) {
				if (dev.VendorID == vendorID && dev.ProductID == productID) {
					list.Add (dev);
				}
			}
			return list.ToArray ();
		}

		public void Dispose()
		{
			Dispose (true);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (disposing) {
				// free managed resources
			}

			// free unmanaged resources
			Internal.Methods.libusb_exit(mvarHandle);
		}
		~UsbContext()
		{
			Dispose (false);
		}
	}
}

