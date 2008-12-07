namespace NHibernate.Hql.Ast
{
	public interface ISyntaxNodeFactory<TClause, TTerminal>
	{
		IClauseNode GetClause(TClause origin);
		ISyntaxNode GetTerminal(TTerminal origin, IClauseNode owner);
	}
}