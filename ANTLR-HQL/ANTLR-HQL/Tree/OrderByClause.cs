using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NHibernate.Hql.Ast.ANTLR.Util;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	/// <summary>
	/// Implementation of OrderByClause.
	/// Author: Steve Ebersole
	/// Ported by: Steve Strong
	/// </summary>
	public class OrderByClause : HqlSqlWalkerNode 
	{
		public OrderByClause(IToken token) : base(token)
		{
		}

		public void AddOrderFragment(string orderByFragment) 
		{
			ITree fragment = ASTUtil.Create( ASTFactory, HqlSqlWalker.SQL_TOKEN, orderByFragment );

			AddChild(fragment);
		}
	}
}
