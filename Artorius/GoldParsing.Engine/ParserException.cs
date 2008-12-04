using System;
using System.Runtime.Serialization;

namespace GoldParsing.Engine
{
	[Serializable]
	public class ParserException : ApplicationException
	{
		public ParserException() {}
		public ParserException(string message) : base(message) {}
		public ParserException(string message, Exception inner) : base(message, inner) {}

		protected ParserException(SerializationInfo info,
		                      StreamingContext context) : base(info, context) {}
	}
}