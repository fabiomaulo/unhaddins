namespace NHibernate.Hql.Ast
{
	public interface INodeVisitor
	{
		void Visit(INode reduction);
	}
}