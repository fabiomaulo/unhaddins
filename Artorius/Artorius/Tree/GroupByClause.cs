using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class GroupByClause: AbstractClauseNode
	{
		internal GroupByClause() {}
		public GroupByClause(params IExpression[] items)
		{
			children[0] = new ExpressionList(items);	
		}

		public ExpressionList ExpressionList
		{
			get
			{
				return children.OfType<ExpressionList>().FirstOrDefault();
			}
		}

		public override bool AddChild(ISyntaxNode node)
		{
			var inner = node as ExpressionList;
			if (inner != null)
			{
				return base.AddChild(node);
			}
			else
			{
				return base.AddChild(new ExpressionList((IExpression)node));
			}
		}
	}
	
}