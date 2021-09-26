//
//  DescriptorType.cs
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

namespace MBS.Framework.USB
{
	public enum DescriptorType : byte
	{
		/** Device descriptor. See libusb_device_descriptor. */
		Device = 0x01,

		/** Configuration descriptor. See libusb_config_descriptor. */
		Configuration = 0x02,

		/** String descriptor */
		String = 0x03,

		/** Interface descriptor. See libusb_interface_descriptor. */
		Interface = 0x04,

		/** Endpoint descriptor. See libusb_endpoint_descriptor. */
		Endpoint = 0x05,

		/** BOS descriptor */
		BOS = 0x0f,

		/** Device Capability descriptor */
		DeviceCapability = 0x10,

		/** HID descriptor */
		HID = 0x21,

		/** HID report descriptor */
		HIDReport = 0x22,

		/** Physical descriptor */
		Physical = 0x23,

		/** Hub descriptor */
		Hub = 0x29,

		/** SuperSpeed Hub descriptor */
		SuperSpeedHub = 0x2A,

		/** SuperSpeed Endpoint Companion descriptor */
		SuperSpeedEndpointCompanion = 0x30
	}
}

