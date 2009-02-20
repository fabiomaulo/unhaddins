using Antlr.Runtime.Tree;

namespace NHibernate.Hql.Ast.ANTLR.Util
{
	public interface IVisitationStrategy
	{
		void Visit(ITree node);
	}
}
