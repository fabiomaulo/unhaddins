using System.Collections.Generic;

namespace NHibernate.Hql.Ast
{
	public interface ISyntaxNode
	{
		ISyntaxNode Parent { get; }
		IEnumerable<ISyntaxNode> Children { get; }
		bool HasChildren { get; }
		void Accept(ISyntaxNodeVisitor visitor);
		void ChildrenAccept(ISyntaxNodeVisitor visitor);
	}
}