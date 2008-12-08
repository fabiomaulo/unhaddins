using System;

namespace NHibernate.Hql.Ast.Tree
{
	public abstract class AbstractLiteralNode : AbstractTerminalNode
	{
		protected AbstractLiteralNode(IClauseNode parentRule, string originalText) : base(parentRule)
		{
			if (originalText == null)
			{
				throw new ArgumentNullException("originalText");
			}
			OriginalText = originalText;
		}

		public string OriginalText { get; internal set; }
		public abstract Type ReturnType { get; }

		public override string ToString()
		{
			return OriginalText;
		}
	}
}