using System.Collections.Generic;

namespace NHibernate.Hql.Ast
{
	public interface INode
	{
		INode Parent { get; }
		IList<INode> Children { get; }
		bool HasChildren { get; }
		void Accept(INodeVisitor visitor);
		void ChildrenAccept(INodeVisitor visitor);
	}
}