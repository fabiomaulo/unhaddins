namespace NHibernate.Hql.Ast.Tree
{
	public class ValueExpression: AbstractClauseNode
	{
		public bool IsSingleValue
		{
			get
			{
				return !IsExpression;
			}
		}

		public bool IsExpression
		{
			get
			{
				return '('.Equals(children[0].ToString()) && ')'.Equals(children[children.Count - 1]);
			}
		}
	}
}