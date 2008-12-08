namespace NHibernate.Hql.Ast.Tree
{
	public class EntityNameExpression : AbstractClauseNode
	{
		internal EntityNameExpression() {}
		public EntityNameExpression(string entityName)
		{
			// TODO : more formal validation
			if (entityName.IndexOf('.') > 0)
				children.Add(new IdentifierPath(this, entityName));
			else
				children.Add(new Identifier(this, entityName));
		}

		public string EntityName
		{
			get { return children[0].ToString(); }
		}
	}
}