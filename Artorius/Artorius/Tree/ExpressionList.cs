namespace NHibernate.Hql.Ast.Tree
{
	public class ExpressionList : AbstractClauseList<IExpression>
	{
		public ExpressionList() {}
		public ExpressionList(params IExpression[] list) : base(list) {}
	}
}