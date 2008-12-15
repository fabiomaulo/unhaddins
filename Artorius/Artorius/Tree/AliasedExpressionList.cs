namespace NHibernate.Hql.Ast.Tree
{
	public class AliasedExpressionList : AbstractClauseList<AliasedExpression>
	{
		public AliasedExpressionList() {}
		public AliasedExpressionList(params AliasedExpression[] list) : base(list) {}
	}
}