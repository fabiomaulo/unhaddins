namespace NHibernate.Hql.Ast
{
	public interface IClauseNode: ISyntaxNode
	{
		void SetParent(IClauseNode parent);
		bool AddChild(ISyntaxNode node);
	}
}