using System.Collections.Generic;
using Antlr.Runtime;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	public interface IASTNode : IEnumerable<IASTNode>
	{
		bool IsNil { get; }
		int Type { get; set; }
		string Text { get; set; }
		int Line { get; }
		int CharPositionInLine { get; }
		int ChildCount { get; }
		int ChildIndex { get; }
		IASTNode Parent { get; set; }
		IASTNode RightHandSibling { get; }
		IASTNode GetChild(int index);
		IASTNode AddChild(IASTNode childNode);
		IASTNode InsertChild(int index, IASTNode child);
		IASTNode AddSiblingToRight(IASTNode newSibling);
		void ClearChildren();
		void AddChildren(IEnumerable<IASTNode> children);
		void AddChildren(params IASTNode[] children);

		IASTNode DupNode();

		// TODO - not sure we need this...
		IToken Token { get; }
		
		string ToStringTree();
	}
}
