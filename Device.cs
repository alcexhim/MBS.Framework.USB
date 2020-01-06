//
//  Device.cs
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
using System.Runtime.InteropServices;

namespace LibUSB
{
	public class Device
	{
		private IntPtr mvarContextHandle = IntPtr.Zero;
		private IntPtr mvarHandle = IntPtr.Zero;

		public ushort VendorID { get; set; }
		public ushort ProductID { get; set; }

		private Internal.Structures.DeviceDescriptor _desc;

		private string mvarManufacturer = null;
		public string Manufacturer 
		{
			get {
				try
				{
					bool needClose = false;
					if (!IsOpen) {
						Open ();
						needClose = true;
					}
					if (mvarManufacturer == null) {
						mvarManufacturer = GetStringDescriptor (_desc.iManufacturer, 0);
					}
					if (needClose) {
						Close ();
					}
				}
				catch {
				}
				return mvarManufacturer;
			}
		}
		private string mvarProduct = null;
		public string Product 
		{
			get {
				try
				{
					bool needClose = false;
					if (!IsOpen) {
						Open ();
						needClose = true;
					}
					if (mvarProduct == null) {
						mvarProduct = GetStringDescriptor (_desc.iProduct, 0);
					}
					if (needClose) {
						Close ();
					}
				}
				catch {
				}
				return mvarProduct;
			}
		}

		public string GetStringDescriptor(byte index, ushort langid)
		{
			ushort length = 128;
			byte[] data = new byte[length];

			ControlTransfer((byte)EndpointDirection.In, (byte)StandardRequests.GetDescriptor, (ushort)(((ushort)DescriptorType.String << 8) | index), langid, data, length, 1000);

			byte[] realdata = new byte[length];
			Array.Copy (data, 2, realdata, 0, data.Length - 2);
			return System.Text.Encoding.Unicode.GetString (realdata);
		}

		public int ControlTransfer(byte requestType, byte request, ushort val, ushort index, byte[] data, ushort length, uint timeout)
		{
			int retval = Internal.Methods.libusb_control_transfer(mvarHandle, requestType,
			request, val, index, data, length, timeout);
			return retval;
		}
		public void BulkTransfer(byte endpoint, byte[] data, out ushort actualLength, uint timeout)
		{
			int retval = Internal.Methods.libusb_bulk_transfer(mvarHandle, endpoint, data, (ushort) data.Length, out actualLength, timeout);
		}

		internal Device (IntPtr contextHandle, Internal.Structures.DeviceDescriptor desc)
		{
			mvarContextHandle = contextHandle;
			_desc = desc;
			VendorID = _desc.idVendor;
			ProductID = _desc.idProduct;
		}

		public bool IsOpen { get { return mvarHandle != IntPtr.Zero; } }

		public void Open ()
		{
			mvarHandle = Internal.Methods.libusb_open_device_with_vid_pid (mvarContextHandle, VendorID, ProductID);
			if (mvarHandle == IntPtr.Zero) {
				Console.WriteLine ("LibUSB.NET warning: libusb_open_device_with_vid_pid returned NULL");
			}
		}

		public void SetConfiguration(int configuration)
		{
			Internal.Methods.libusb_set_configuration(mvarHandle, configuration);
		}
		public void ClaimInterface(int intf)
		{
			Internal.Methods.libusb_claim_interface (mvarHandle, intf);
		}
		public void ReleaseInterface(int intf)
		{
			Internal.Methods.libusb_release_interface (mvarHandle, intf);
		}

		public void Close()
		{
			Internal.Methods.libusb_close (mvarHandle);
			mvarHandle = IntPtr.Zero;
		}

		public override string ToString ()
		{
			return String.Format ("{0}:{1}", VendorID.ToString("x").PadLeft(4, '0'), ProductID.ToString("x").PadLeft(4, '0'));
		}
	}
}

