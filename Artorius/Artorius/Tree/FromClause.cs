using System.Linq;

namespace NHibernate.Hql.Ast.Tree
{
	public class FromClause : AbstractClauseNode
	{
		public FromClause() {}

		public FromClause(string entityName)
		{
			children.Add(new AliasedEntityNameList(new AliasedEntityNameExpression(entityName, null)));
		}

		public FromClause(AliasedEntityNameList entityNameList)
		{
			children.Add(entityNameList);
		}

		public AliasedEntityNameList EntityNames
		{
			get { return children.OfType<AliasedEntityNameList>().First(); }
		}

		public OrderByClause OrderBy
		{
			get { return children.OfType<OrderByClause>().FirstOrDefault(); }
		}

		public GroupByClause GroupBy
		{
			get { return children.OfType<GroupByClause>().FirstOrDefault(); }
		}

		public override bool AddChild(ISyntaxNode node)
		{
			var aene = node as AliasedEntityNameExpression;
			if (aene != null)
			{
				AddChild(aene);
			}
			var ene = node as EntityNameExpression;
			if (ene != null)
			{
				AddChild(ene);
			}
			return base.AddChild(node);
		}

		public bool AddChild(AliasedEntityNameExpression node)
		{
			AliasedEntityNameList existingList = children.OfType<AliasedEntityNameList>().FirstOrDefault();
			if (existingList != null)
			{
				return existingList.AddChild(node);
			}
			else
			{
				return AddChild(new AliasedEntityNameList(node));
			}
		}

		public bool AddChild(EntityNameExpression node)
		{
			AliasedEntityNameList existingList = children.OfType<AliasedEntityNameList>().FirstOrDefault();
			if (existingList != null)
			{
				return existingList.AddChild(new AliasedEntityNameExpression(node, null));
			}
			else
			{
				return AddChild(new AliasedEntityNameList(new AliasedEntityNameExpression(node, null)));
			}
		}
	}
}