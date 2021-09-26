using System;
namespace MBS.Framework.USB.Internal
{
	internal static class Constants
	{
		public enum LibUSBError
		{
			/// <summary>
			/// Success (no error).
			/// </summary>
			Success = 0,
			/// <summary>
			/// Input/output error.
			/// </summary>
			InputOutputError = -1,
			/// <summary>
			/// Invalid parameter.
			/// </summary>
			InvalidParameter = -2,
			/// <summary>
			/// Access denied (insufficient permissions).
			/// </summary>
			AccessDenied = -3,
			/// <summary>
			/// No such device (it may have been disconnected).
			/// </summary>
			NoDevice = -4,
			/// <summary>
			/// Entity not found.
			/// </summary>
			NotFound = -5,
			/// <summary>
			/// Resource busy.
			/// </summary>
			Busy = -6,
			/// <summary>
			/// Operation timed out.
			/// </summary>
			Timeout = -7,
			/// <summary>
			/// Overflow.
			/// </summary>
			Overflow = -8,
			/// <summary>
			/// Pipe error.
			/// </summary>
			Pipe = -9,
			/// <summary>
			/// System call interrupted (perhaps due to signal)
			/// </summary>
			Interrupted = -10,
			/// <summary>
			/// Insufficient memory
			/// </summary>
			InsufficientMemory = -11,
			/// <summary>
			/// Operation not supported or unimplemented on this platform.
			/// </summary>
			NotSupported = -12,
			/// <summary>
			/// Other error.
			/// </summary>
			Other = -99,
		}
	}
}
