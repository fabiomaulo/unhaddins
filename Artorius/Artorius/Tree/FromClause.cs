namespace NHibernate.Hql.Ast.Tree
{
	public class FromClause: AbstractClauseNode
	{
		internal FromClause() {}

		public FromClause(string entityName)
		{
			children.Add(new EntityNameExpression(entityName));
		}

		public FromClause(AliasedEntityNameList entityNameList)
		{
			children.Add(entityNameList);
		}

	}
}