﻿using System;
using Antlr.Runtime;
using NHibernate.Engine;
using NHibernate.Type;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	/**
	 * Represents a boolean literal within a query.
	 *
	 * @author Steve Ebersole
	 */
	public class BooleanLiteralNode : LiteralNode, IExpectedTypeAwareNode 
	{
		private IType expectedType;

		public BooleanLiteralNode(IToken token) : base(token)
		{
		}

		public override IType DataType
		{
			get
			{
				return expectedType ?? NHibernateUtil.Boolean;
			}
			set
			{
				base.DataType = value;
			}
		}

		private BooleanType GetTypeInternal() 
		{
			return ( BooleanType ) DataType;
		}

		private bool GetValue() {
			return Type == HqlSqlWalker.TRUE ? true : false;
		}

		/**
		 * Expected-types really only pertinent here for boolean literals...
		 *
		 * @param expectedType
		 */
		public IType ExpectedType
		{
			get { return expectedType; }
			set { expectedType = value; }
		}

		public override string RenderText(ISessionFactoryImplementor sessionFactory) 
		{
			try
			{
				return GetTypeInternal().ObjectToSQLString( GetValue(), sessionFactory.Dialect );
			}
			catch( Exception t )
			{
				throw new QueryException( "Unable to render boolean literal value", t );
			}
		}
	}
}
