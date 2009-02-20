using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NHibernate.Hql.Ast.ANTLR.Util;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	public abstract class AbstractRestrictableStatement : AbstractStatement, IRestrictableStatement
	{
		private FromClause _fromClause;

		protected AbstractRestrictableStatement(IToken token) : base(token)
		{
		}

		public FromClause FromClause
		{
			get
			{
				if (_fromClause == null)
				{
					_fromClause = (FromClause)ASTUtil.FindTypeInChildren(this, HqlSqlWalker.FROM);
				}
				return _fromClause;
			}
		}

		public bool HasWhereClause
		{
			get { throw new System.NotImplementedException(); }
		}

		public ITree WhereClause
		{
			get { throw new System.NotImplementedException(); }
		}
	}
}
