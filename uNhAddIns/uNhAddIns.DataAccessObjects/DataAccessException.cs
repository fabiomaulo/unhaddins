using System;
using System.Runtime.Serialization;

namespace uNhAddIns.DataAccessObjects
{
	[Serializable]
	public class DataAccessException : ApplicationException
	{
		internal DataAccessException() {}
		public DataAccessException(string message) : base(message) {}
		public DataAccessException(string message, Exception inner) : base(message, inner) {}

		protected DataAccessException(SerializationInfo info, StreamingContext context) : base(info, context) {}
	}
}