﻿//
//  Structures.cs
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

namespace LibUSB.Internal
{
	public class Structures
	{
		public struct DeviceDescriptor
		{
			/** Size of this descriptor (in bytes) */
			public byte bLength;

			/** Descriptor type. Will have value
 * \ref libusb_descriptor_type::LIBUSB_DT_DEVICE LIBUSB_DT_DEVICE in this
 * context. */
			public DescriptorType bDescriptorType;

			/** USB specification release number in binary-coded decimal. A value of
 * 0x0200 indicates USB 2.0, 0x0110 indicates USB 1.1, etc. */
			public ushort bcdUSB;

			/** USB-IF class code for the device. See \ref libusb_class_code. */
			public ClassCode bDeviceClass;

			/** USB-IF subclass code for the device, qualified by the bDeviceClass
 * value */
			public byte bDeviceSubClass;

			/** USB-IF protocol code for the device, qualified by the bDeviceClass and
 * bDeviceSubClass values */
			public byte  bDeviceProtocol;

			/** Maximum packet size for endpoint 0 */
			public byte  bMaxPacketSize0;

			/** USB-IF vendor ID */
			public ushort idVendor;

			/** USB-IF product ID */
			public ushort idProduct;

			/** Device release number in binary-coded decimal */
			public ushort bcdDevice;

			/** Index of string descriptor describing manufacturer */
			public byte  iManufacturer;

			/** Index of string descriptor describing product */
			public byte  iProduct;

			/** Index of string descriptor containing device serial number */
			public byte  iSerialNumber;

			/** Number of possible configurations */
			public byte  bNumConfigurations;
		}
	}
}

