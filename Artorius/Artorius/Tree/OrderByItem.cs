namespace NHibernate.Hql.Ast.Tree
{
	public class OrderByItem: AbstractClauseNode
	{
		internal OrderByItem() {}

		public IExpression Item
		{
			get { return (IExpression) children[0]; }
		}

		public OrderType OrderType
		{
			get
			{
				if (children.Count > 1)
				{
					return ((OrderingSpecification) children[1]).OrderType;
				}
				else
				{
					return OrderType.Ascending;
				}
			}
		}

		public override string ToString()
		{
			if (children.Count == 1)
				return Item.ToString();
			else
				return string.Concat(Item, " ", children[1]);
		}
	}
}