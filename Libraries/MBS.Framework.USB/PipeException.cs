using System;
using System.Runtime.Serialization;

namespace MBS.Framework.USB
{
	[Serializable()]
	public class PipeException : UsbException
	{
		public PipeException() : base() { }
		protected PipeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
		public PipeException(string message) : base(message) { }
		public PipeException(string message, Exception innerException) : base(message, innerException) { }
	}
}
