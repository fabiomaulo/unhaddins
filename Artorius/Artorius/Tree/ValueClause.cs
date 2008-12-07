namespace NHibernate.Hql.Ast.Tree
{
	public class ValueClause: AbstractClauseNode
	{
		public bool IsSingleValue
		{
			get
			{
				return !'('.Equals(children[0].ToString());
			}
		}

		public string GetValueAsString()
		{
			if (IsSingleValue)
			{
				return ((AbstractLiteralNode) children[0]).OriginalText;
			}
			throw new QueryParserException("Requiring Value for a complex expression.");
		}
	}
}