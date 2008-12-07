using System;

namespace NHibernate.Hql.Ast.Tree
{
	public abstract class AbstractLiteralNode : AbstractTerminalNode
	{
		protected AbstractLiteralNode(IClauseNode parentRule) : base(parentRule) {}
		public string OriginalText { get; set; }
		public abstract Type ReturnType { get; }
	}
}