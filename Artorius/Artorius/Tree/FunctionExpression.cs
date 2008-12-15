namespace NHibernate.Hql.Ast.Tree
{
	public class FunctionExpression : AbstractClauseNode
	{
		internal FunctionExpression() {}

		public string Name
		{
			get { return children[0].ToString(); }
		}
	}
}