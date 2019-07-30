//
//  StandardRequests.cs
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

namespace LibUSB
{
	public enum StandardRequests : byte
	{
			/** Request status of the specific recipient */
			GetStatus = 0x00,

			/** Clear or disable a specific feature */
			ClearFeature = 0x01,

			/* 0x02 is reserved */

			/** Set or enable a specific feature */
			SetFeature = 0x03,

			/* 0x04 is reserved */

			/** Set device address for all future accesses */
			SetAddress = 0x05,

			/** Get the specified descriptor */
			GetDescriptor = 0x06,

			/** Used to update existing descriptors or add new descriptors */
			SetDescriptor = 0x07,

			/** Get the current device configuration value */
			GetConfiguration = 0x08,

			/** Set device configuration */
			SetConfiguration = 0x09,

			/** Return the selected alternate setting for the specified interface */
			GetInterface = 0x0A,

			/** Select an alternate interface for the specified interface */
			SetInterface = 0x0B,

			/** Set then report an endpoint's synchronization frame */
			RequestSynchFrame = 0x0C,

			/** Sets both the U1 and U2 Exit wLatency */
			RequestSetSel = 0x30,

			/** Delay from the time a host transmits a packet to the time it is
	  * received by the device. */
			SetIsochDelay = 0x31,
	}
}

