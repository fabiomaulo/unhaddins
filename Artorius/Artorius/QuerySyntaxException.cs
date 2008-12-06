using System;
using System.Runtime.Serialization;
using System.Text;

namespace NHibernate.Hql.Ast
{
	[Serializable]
	public class QuerySyntaxException : QueryParsingException
	{
		private readonly Info info;

		public struct Info
		{
			public string Query;
			public int Line;
			public int Column;
			public string Expected;
			public string Found;
		}

		public QuerySyntaxException(string message, Info info)
			: base(message, info.Query, info.Line, info.Column)
		{
			this.info = info;
		}

		protected QuerySyntaxException(SerializationInfo info,
		                      StreamingContext context) : base(info, context) {}

		public QuerySyntaxException(string message, Info info, Exception inner)
			: base(message, info.Query, info.Line, info.Column, inner)
		{
			this.info = info;
		}

		public Info ParsingInfo
		{
			get { return info; }
		}

		protected override string FormatMessage(string message)
		{
			return
				new StringBuilder(base.FormatMessage(message))
				.AppendLine("Expected :" + info.Expected)
				.AppendLine("Found    :" + info.Found)
				.ToString();
		}
	}
}