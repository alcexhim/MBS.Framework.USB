using System;
using System.Runtime.Serialization;

namespace MBS.Framework.USB
{
	[Serializable()]
	public class SystemCallInterruptedException : UsbException
	{
		public SystemCallInterruptedException() : base() { }
		protected SystemCallInterruptedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
		public SystemCallInterruptedException(string message) : base(message) { }
		public SystemCallInterruptedException(string message, Exception innerException) : base(message, innerException) { }
	}
}
