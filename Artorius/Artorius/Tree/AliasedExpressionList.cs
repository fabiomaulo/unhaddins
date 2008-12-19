using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class AliasedExpressionList : AbstractClauseList<AliasedExpression>
	{
		public AliasedExpressionList() {}
		public AliasedExpressionList(params AliasedExpression[] list) : base(list) {}

		public override bool AddChild(ISyntaxNode node)
		{
			var inner = node as AliasedExpressionList;
			if (inner != null)
			{
				foreach (AliasedExpression child in inner.Children.OfType<AliasedExpression>())
				{
					base.AddChild(child);
				}
				return true;
			}
			else
			{
				return base.AddChild(node);
			}
		}
	}
}