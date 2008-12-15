using System;

namespace NHibernate.Hql.Ast.Tree
{
	public abstract class AbstractLiteralNode : AbstractTerminalNode, ILiteralNode
	{
		protected AbstractLiteralNode(IClauseNode parentRule, string originalText) : base(parentRule)
		{
			if (originalText == null)
			{
				throw new ArgumentNullException("originalText");
			}
			AsString = originalText;
		}

		public string AsString { get; internal set; }
		public abstract System.Type ReturnType { get; }

		public override string ToString()
		{
			return AsString;
		}
	}
}