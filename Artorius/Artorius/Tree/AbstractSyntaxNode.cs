using System.Collections.Generic;

namespace NHibernate.Hql.Ast.Tree
{
	public abstract class AbstractSyntaxNode: ISyntaxNode
	{
		#region Implementation of ISyntaxNode

		public abstract ISyntaxNode Parent { get; }
		public abstract IEnumerable<ISyntaxNode> Children { get; }
		public abstract bool HasChildren { get; }

		public void Accept(ISyntaxNodeVisitor visitor)
		{
			visitor.Visit(this);
		}

		public void ChildrenAccept(ISyntaxNodeVisitor visitor)
		{
			if (HasChildren)
			{
				foreach (var syntaxNode in Children)
				{
					syntaxNode.Accept(visitor);
				}
			}
		}

		#endregion
	}
}