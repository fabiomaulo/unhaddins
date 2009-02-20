using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NHibernate.Hql.Ast.ANTLR.Util;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	public class QueryNode : AbstractRestrictableStatement, ISelectExpression
	{
		Logger log = new Logger();

		private OrderByClause _orderByClause;

		public QueryNode(IToken token) : base(token)
		{
		}

		public override bool NeedsExecutor
		{
			get { return false; }
		}

		public override int StatementType
		{
			get { return HqlSqlWalker.QUERY; }
		}

		public void SetScalarColumnText(int i)
		{
			throw new System.NotImplementedException();
		}

		public FromElement FromElement
		{
			get { throw new System.NotImplementedException(); }
		}

		public bool IsConstructor
		{
			get { throw new System.NotImplementedException(); }
		}

		public bool IsReturnableEntity
		{
			get { throw new System.NotImplementedException(); }
		}

		public bool IsScalar
		{
			get { throw new System.NotImplementedException(); }
		}

		public string Alias
		{
			get { throw new System.NotImplementedException(); }
			set { throw new System.NotImplementedException(); }
		}

		public OrderByClause GetOrderByClause() 
		{
			if (_orderByClause == null) 
			{
				_orderByClause = LocateOrderByClause();

				// if there is no order by, make one
				if (_orderByClause == null)
				{
					log.debug( "getOrderByClause() : Creating a new ORDER BY clause" );
					_orderByClause = (OrderByClause)ASTUtil.Create(Walker.ASTFactory, HqlSqlWalker.ORDER, "ORDER");

					// Find the WHERE; if there is no WHERE, find the FROM...
					ITree prevSibling = ASTUtil.FindTypeInChildren(this, HqlSqlWalker.WHERE);

					if ( prevSibling == null ) 
					{
						prevSibling = ASTUtil.FindTypeInChildren(this, HqlSqlWalker.FROM);
					}

					// Now, inject the newly built ORDER BY into the tree
					ASTUtil.AppendSibling(prevSibling, _orderByClause);
				}
			}
			return _orderByClause;
		}

		private OrderByClause LocateOrderByClause()
		{
			return (OrderByClause)ASTUtil.FindTypeInChildren(this, HqlSqlWalker.ORDER);
		}

	}
}
