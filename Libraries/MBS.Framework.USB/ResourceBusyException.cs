using System;
using System.Runtime.Serialization;

namespace MBS.Framework.USB
{
	[Serializable()]
	public class ResourceBusyException : UsbException
	{
		public ResourceBusyException() : base() { }
		protected ResourceBusyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
		public ResourceBusyException(string message) : base(message) { }
		public ResourceBusyException(string message, Exception innerException) : base(message, innerException) { }
	}
}
