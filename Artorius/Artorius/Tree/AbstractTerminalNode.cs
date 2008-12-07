using System.Collections.Generic;

namespace NHibernate.Hql.Ast.Tree
{
	public abstract class AbstractTerminalNode: AbstractSyntaxNode
	{
		// TODO : add abstract method for translation
		protected readonly IClauseNode parentRule;

		protected AbstractTerminalNode(IClauseNode parentRule)
		{
			this.parentRule = parentRule;
		}

		public override ISyntaxNode Parent
		{
			get { return parentRule; }
		}

		public override IEnumerable<ISyntaxNode> Children
		{
			get { return null; }
		}

		public override bool HasChildren
		{
			get { return false; }
		}
	}
}