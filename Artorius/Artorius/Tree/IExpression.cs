namespace NHibernate.Hql.Ast.Tree
{
	public interface IExpression: IClauseNode
	{
		ExpType ExpressionType { get; }
	}
}