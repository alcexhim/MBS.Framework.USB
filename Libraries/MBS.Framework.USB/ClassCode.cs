//
//  ClassCode.cs
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
	public enum ClassCode : byte
	{
		/** In the context of a \ref libusb_device_descriptor "device descriptor",
	 * this bDeviceClass value indicates that each interface specifies its
	 * own class information and all interfaces operate independently.
	 */
		PerInterface = 0,

		/** Audio class */
		Audio = 1,

		/** Communications class */
		Communications = 2,

		/** Human Interface Device class */
		HID = 3,

		/** Physical */
		Physical = 5,

		/** Printer class */
		Printer = 7,

		/** Image class */
		Image = 6, /* legacy name from libusb-0.1 usb.h */

		/** Mass storage class */
		MassStorage = 8,

		/** Hub class */
		Hub = 9,

		/** Data class */
		Data = 10,

		/** Smart Card */
		SmartCard = 0x0b,

		/** Content Security */
		ContentSecurity = 0x0d,

		/** Video */
		Video = 0x0e,

		/** Personal Healthcare */
		PersonalHealthcare = 0x0f,

		/** Diagnostic Device */
		DiagnosticDevice = 0xdc,

		/** Wireless class */
		Wireless = 0xe0,

		/** Application class */
		Application = 0xfe,

		/** Class is vendor-specific */
		VendorSpecific = 0xff
	}
}

