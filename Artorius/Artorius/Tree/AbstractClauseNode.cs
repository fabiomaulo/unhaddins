using System;
using System.Collections.Generic;

namespace NHibernate.Hql.Ast.Tree
{
	public abstract class AbstractClauseNode : AbstractSyntaxNode, IClauseNode
	{
		// TODO : add abstract method for translation
		protected readonly List<ISyntaxNode> children = new List<ISyntaxNode>();
		protected IClauseNode parent;

		#region Overrides of AbstractSyntaxNode

		public override ISyntaxNode Parent
		{
			get { return parent; }
		}

		public override IEnumerable<ISyntaxNode> Children
		{
			get { return children; }
		}

		public override bool HasChildren
		{
			get { return children != null && children.Count > 0; }
		}

		#endregion

		#region Implementation of IClauseNode

		public virtual void SetParent(IClauseNode parentClause)
		{
			if (parentClause == null)
			{
				throw new ArgumentNullException("parentClause");
			}
			parent = parentClause;
		}

		public virtual bool AddChild(ISyntaxNode node)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			children.Add(node);
			return true;
		}

		#endregion
	}
}