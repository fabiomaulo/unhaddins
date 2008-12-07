using System;
using System.Runtime.Serialization;

namespace NHibernate.Hql.Ast
{
	[Serializable]
	public class QueryParserException : ApplicationException
	{
		public QueryParserException() {}
		public QueryParserException(string message) : base(message) {}
		public QueryParserException(string message, Exception inner) : base(message, inner) {}

		protected QueryParserException(SerializationInfo info,
		                      StreamingContext context) : base(info, context) {}
	}
}