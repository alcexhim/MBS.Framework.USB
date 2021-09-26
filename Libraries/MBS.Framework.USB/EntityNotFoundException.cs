using System;
using System.Runtime.Serialization;

namespace MBS.Framework.USB
{
	[Serializable()]
	public class EntityNotFoundException : UsbException
	{
		public EntityNotFoundException() : base() { }
		protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
		public EntityNotFoundException(string message) : base(message) { }
		public EntityNotFoundException(string message, Exception innerException) : base(message, innerException) { }
	}
}
