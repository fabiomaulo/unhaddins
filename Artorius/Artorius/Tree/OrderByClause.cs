using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class OrderByClause : AbstractClauseNode
	{
		internal OrderByClause() {}
		public OrderByClause(params OrderByItem[] items)
		{
			children[0] = new OrderByList(items);	
		}

		public OrderByList OrderList
		{
			get
			{
				return children.OfType<OrderByList>().FirstOrDefault();
			}
		}
	}
}