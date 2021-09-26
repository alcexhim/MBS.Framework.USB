//
//  Methods.cs
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
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MBS.Framework.USB.Internal
{
	internal class Methods
	{
		public const string LIBRARY_FILENAME = "libusb-1.0.so.0";

		[DllImport(LIBRARY_FILENAME)]
		public static extern Constants.LibUSBError libusb_init(ref IntPtr /*libusb_context**/ ctx);
		[DllImport(LIBRARY_FILENAME)]
		public static extern void libusb_exit(IntPtr /*libusb_context**/ ctx);
		[DllImport(LIBRARY_FILENAME)]
		public static extern void libusb_set_debug(IntPtr /*libusb_context*/ ctx, int level);

		[DllImport(LIBRARY_FILENAME)]
		public static extern int libusb_get_device_list(IntPtr /*libusb_context*/ ctx, ref IntPtr /*libusb_device ***/ list);
		[DllImport(LIBRARY_FILENAME)]
		public static extern Constants.LibUSBError libusb_get_device_descriptor(IntPtr /*libusb_device*/ dev, ref Structures.DeviceDescriptor desc);

		[DllImport(LIBRARY_FILENAME)]
		public static extern IntPtr libusb_open_device_with_vid_pid(IntPtr /*libusb_context*/ ctx, ushort vid, ushort pid);
		[DllImport(LIBRARY_FILENAME)]
		public static extern void libusb_close(IntPtr /*libusb_device_handle**/ dev);

		[DllImport(LIBRARY_FILENAME)]
		public static extern Constants.LibUSBError libusb_set_configuration(IntPtr /*libusb_device_handle*/ dev_handle, int configuration);

		[DllImport(LIBRARY_FILENAME)]
		public static extern Constants.LibUSBError libusb_claim_interface(IntPtr /*libusb_device_handle*/ dev_handle, int interface_number);
		[DllImport(LIBRARY_FILENAME)]
		public static extern Constants.LibUSBError libusb_release_interface(IntPtr /*libusb_device_handle*/ dev_handle, int interface_number);


		// sync io
		[DllImport(LIBRARY_FILENAME)]
		public static extern Internal.Constants.LibUSBError libusb_control_transfer(IntPtr dev, byte bmRequestType, byte bRequest, ushort wValue, ushort wIndex, byte[] data, ushort wLength, uint timeout);

		[DllImport(LIBRARY_FILENAME)]
		public static extern Constants.LibUSBError libusb_bulk_transfer(IntPtr dev, byte endpoint, byte[] data, int length, ref int actual_length, uint timeout);

		public static Internal.Constants.LibUSBError libusb_get_string_descriptor(IntPtr handle, byte index, ushort langid, byte[] data, ushort length)
		{
			return libusb_control_transfer(handle, (byte)EndpointDirection.In,
				(byte)StandardRequests.GetDescriptor, (ushort)(((ushort)DescriptorType.String << 8) | index),
				langid, data, length, 1000);
		}

		[DebuggerNonUserCode()]
		internal static void libusb_error_to_exception(Constants.LibUSBError retval)
		{
			switch (retval)
			{
				case Constants.LibUSBError.AccessDenied: throw new AccessViolationException();
				case Constants.LibUSBError.Busy: throw new ResourceBusyException();
				case Constants.LibUSBError.InputOutputError: throw new System.IO.IOException();
				case Constants.LibUSBError.InsufficientMemory: throw new InsufficientMemoryException();
				case Constants.LibUSBError.Interrupted: throw new SystemCallInterruptedException();
				case Constants.LibUSBError.InvalidParameter: throw new ArgumentException();
				case Constants.LibUSBError.NoDevice: throw new DeviceNotFoundException();
				case Constants.LibUSBError.NotFound: throw new EntityNotFoundException();
				case Constants.LibUSBError.NotSupported: throw new PlatformNotSupportedException();
				case Constants.LibUSBError.Other: throw new UsbException();
				case Constants.LibUSBError.Overflow: throw new OverflowException();
				case Constants.LibUSBError.Pipe: throw new PipeException();
				case Constants.LibUSBError.Success: return; // yay!
				case Constants.LibUSBError.Timeout: throw new TimeoutException();
			}
		}

		[DllImport(LIBRARY_FILENAME)]
		public static extern Internal.Constants.LibUSBError libusb_get_active_config_descriptor(IntPtr mvarHandle, ref Structures.ConfigDescriptor config);

		[DllImport(LIBRARY_FILENAME)]
		public static extern Constants.LibUSBError libusb_detach_kernel_driver(IntPtr device, int interfaceNumber);

		[DllImport(LIBRARY_FILENAME)]
		public static extern Constants.LibUSBError libusb_attach_kernel_driver(IntPtr device, int interfaceNumber);

		[DllImport(LIBRARY_FILENAME)]
		public static extern int libusb_kernel_driver_active(IntPtr device, int interfaceNumber);
	}
}

