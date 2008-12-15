using System;

namespace NHibernate.Hql.Ast.Tree
{
	public enum OrderType
	{
		Ascending,
		Descending
	}

	public class OrderingSpecification : AbstractClauseNode
	{
		internal OrderingSpecification() {}

		public OrderType OrderType
		{
			get { return ToOrderType(children[0].ToString()); }
		}

		private static OrderType ToOrderType(string orderType)
		{
			switch (orderType.ToLowerInvariant())
			{
				case "asc":
				case "ascending":
					return OrderType.Ascending;
				case "desc":
				case "descending":
					return OrderType.Descending;
			}
			throw new QueryParserException("Unmanaged OrderType:" + orderType);
		}

		private static string OrderTypeToString(OrderType orderType)
		{
			switch (orderType)
			{
				case OrderType.Ascending:
					return "asc";
				case OrderType.Descending:
					return "desc";
				default:
					throw new ArgumentOutOfRangeException("orderType");
			}
		}

		public override string ToString()
		{
			return children[0].ToString();
		}
	}
}