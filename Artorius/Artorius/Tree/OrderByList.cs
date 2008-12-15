using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class OrderByList : AbstractClauseList<OrderByItem>
	{
		public OrderByList() {}
		public OrderByList(params OrderByItem[] items) : base(items) {}

		public override bool AddChild(ISyntaxNode node)
		{
			var inner = node as OrderByList;
			if (inner != null)
			{
				foreach (OrderByItem child in inner.Children.OfType<OrderByItem>())
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