using System;
using System.Runtime.Serialization;
using System.Text;

namespace NHibernate.Hql.Ast
{
	[Serializable]
	public class QueryParsingException : ApplicationException
	{
		protected readonly int column;
		protected readonly int line;
		protected readonly string query;

		public QueryParsingException(string message, string query, int line, int column) : base(message)
		{
			this.query = query;
			this.line = line;
			this.column = column;
		}

		public QueryParsingException(string message, string query, int line, int column, Exception inner)
			: base(message, inner)
		{
			this.query = query;
			this.line = line;
			this.column = column;
		}

		protected QueryParsingException(SerializationInfo info, StreamingContext context) : base(info, context) {}

		public override string Message
		{
			get { return FormatMessage(base.Message); }
		}

		protected virtual string FormatMessage(string message)
		{
			var sb = new StringBuilder();
			if (!string.IsNullOrEmpty(message))
			{
				sb.AppendLine(message);
			}
			sb.AppendLine("On query:").AppendLine(query).AppendLine("In Line " + line + ", Column " + column);
			return sb.ToString();
		}
	}
}