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

namespace MBS.Framework.USB
{
	public class UsbDevice
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

        public string GetStringDescriptor(StringDescriptorType type, ushort langid)
        {
            return GetStringDescriptor((byte)type, langid);
        }
        public string GetStringDescriptor(byte index, ushort langid)
		{
			ushort length = 128;
			byte[] data = new byte[length];

			ControlTransfer((byte)EndpointDirection.In, (byte)StandardRequests.GetDescriptor, (ushort)(((ushort)DescriptorType.String << 8) | index), langid, data, 1000);

			byte[] realdata = new byte[length];
			Array.Copy (data, 2, realdata, 0, data.Length - 2);
			return System.Text.Encoding.Unicode.GetString (realdata);
		}

		public void ControlTransfer(byte requestType, byte request, ushort val, ushort index, byte[] data, uint timeout)
		{
            ushort len = 0;
            if (data != null)
                len = (ushort)data.Length;

			Internal.Constants.LibUSBError retval = Internal.Methods.libusb_control_transfer(mvarHandle, requestType,
			request, val, index, data, len, timeout);
			Internal.Methods.libusb_error_to_exception(retval);
		}
		public void BulkTransfer(byte endpoint, byte[] data, out int actualLength, uint timeout)
		{
			actualLength = 0;
			Internal.Constants.LibUSBError retval = Internal.Methods.libusb_bulk_transfer(mvarHandle, endpoint, data, data.Length, ref actualLength, timeout);
			Internal.Methods.libusb_error_to_exception(retval);
		}

		internal UsbDevice (IntPtr contextHandle, Internal.Structures.DeviceDescriptor desc)
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
                throw new InvalidOperationException();
			}
		}

		public void SetConfiguration(int configuration)
		{
			Internal.Constants.LibUSBError v = Internal.Methods.libusb_set_configuration(mvarHandle, configuration);
			Internal.Methods.libusb_error_to_exception(v);
		}
		public void ClaimInterface(int intf)
		{
			Internal.Constants.LibUSBError v = Internal.Methods.libusb_claim_interface (mvarHandle, intf);
			Internal.Methods.libusb_error_to_exception(v);
		}
		public void ReleaseInterface(int intf)
		{
			Internal.Constants.LibUSBError v = Internal.Methods.libusb_release_interface (mvarHandle, intf);
			Internal.Methods.libusb_error_to_exception(v);
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

		public void Write(byte endpoint, string value)
		{
			BulkTransfer(endpoint, System.Text.Encoding.UTF8.GetBytes(value), out int actualLength, 0);
		}

		public int GetActiveConfiguration()
		{
			Internal.Structures.ConfigDescriptor config = new Internal.Structures.ConfigDescriptor();
			Internal.Methods.libusb_get_active_config_descriptor(mvarHandle, ref config);
			return 0;
		}

		public bool IsKernelDriverActive(int interfaceNumber)
		{
			int val = Internal.Methods.libusb_kernel_driver_active(mvarHandle, interfaceNumber);
			return (val != 0);
		}
		public void DetachKernelDriver(int interfaceNumber)
		{
			Internal.Constants.LibUSBError retval = Internal.Methods.libusb_detach_kernel_driver(mvarHandle, interfaceNumber);
			Internal.Methods.libusb_error_to_exception(retval);
		}
		public void AttachKernelDriver(int interfaceNumber)
		{
			Internal.Constants.LibUSBError retval = Internal.Methods.libusb_attach_kernel_driver(mvarHandle, interfaceNumber);
			Internal.Methods.libusb_error_to_exception(retval);
		}
	}
}

