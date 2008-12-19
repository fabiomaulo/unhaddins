using System;
using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class AliasedEntityNameList : AbstractClauseList<AbstractAliasedEntityExpression>
	{
		internal AliasedEntityNameList() {}

		public AliasedEntityNameList(params AliasedEntityNameExpression[] list)
		{
			if (list == null || list.Length == 0)
			{
				throw new ArgumentNullException("list", "The list must be not null and not empty.");
			}
			children.AddRange(list);
		}

		public override bool AddChild(ISyntaxNode node)
		{
			var inner = node as AliasedEntityNameList;
			if (inner != null)
			{
				return AddChild(inner);
			}
			return base.AddChild(node);
		}

		public bool AddChild(AliasedEntityNameList node)
		{
			foreach (AbstractAliasedEntityExpression child in node.Children.OfType<AbstractAliasedEntityExpression>())
			{
				base.AddChild(child);
			}
			return true;
		}
	}
}