namespace NHibernate.Hql.Ast
{
	public interface ISyntaxNodeVisitor
	{
		void Visit(ISyntaxNode syntaxNode);
	}
}