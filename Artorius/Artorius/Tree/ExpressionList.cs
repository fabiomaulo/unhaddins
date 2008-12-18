using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class ExpressionList : AbstractClauseList<IExpression>
	{
		public ExpressionList() {}
		public ExpressionList(params IExpression[] list) : base(list) {}

		public override bool AddChild(ISyntaxNode node)
		{
			var inner = node as ExpressionList;
			if (inner != null)
			{
				foreach (IExpression child in inner.Children.OfType<IExpression>())
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