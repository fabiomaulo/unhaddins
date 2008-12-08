using System;
using System.Collections.Generic;
using System.Text;

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
			if(!ReferenceEquals(node.Parent,this))
			{
				throw new ArgumentNullException("node", "Invalid node reparenting.");				
			}
			children.Add(node);
			return true;
		}

		#endregion

		public override string ToString()
		{
			var result = new StringBuilder(50);
			foreach (var node in children)
			{
				result.Append(node);
			}
			return result.ToString();
		}
	}
}