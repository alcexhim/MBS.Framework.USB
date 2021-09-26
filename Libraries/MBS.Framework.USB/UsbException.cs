using System;
using System.Runtime.Serialization;

namespace MBS.Framework.USB
{
	public class UsbException : Exception
	{
		public UsbException() : base() { }
		protected UsbException(SerializationInfo info, StreamingContext context) : base(info, context) { }
		public UsbException(string message) : base(message) { }
		public UsbException(string message, Exception innerException) : base(message, innerException) { }
	}
}
