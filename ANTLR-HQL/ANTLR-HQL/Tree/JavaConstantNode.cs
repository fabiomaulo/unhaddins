using System;
using Antlr.Runtime;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR.Util;
using NHibernate.Type;

namespace NHibernate.Hql.Ast.ANTLR.Tree
{
	/// <summary>
	/// A node representing a static Java constant.
	/// 
	/// Author: Steve Ebersole
	/// Ported by: Steve Strong
	/// </summary>
	public class JavaConstantNode : SqlNode, IExpectedTypeAwareNode, ISessionFactoryAwareNode 
	{
		private ISessionFactoryImplementor _factory;
		private String _constantExpression;
		private Object _constantValue;
		private IType _heuristicType;
		private IType _expectedType;

		public JavaConstantNode(IToken token) : base(token)
		{
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				// for some reason the antlr.CommonAST initialization routines force
				// this method to get called twice.  The first time with an empty string
				if (!string.IsNullOrEmpty(value))
				{
					_constantExpression = value;
					_constantValue = ReflectHelper2.GetConstantValue(value);
					_heuristicType = TypeFactory.HeuristicType(_constantValue.GetType().Name);
					base.Text = value;
				}
			}
		}

		public IType ExpectedType
		{
			get { return _expectedType; }
			set { _expectedType = value; }
		}

		public ISessionFactoryImplementor SessionFactory
		{
			set { _factory = value; }
		}

		private string ResolveToLiteralString(IType type) 
		{
			try 
			{
				ILiteralType literalType = ( ILiteralType ) type;
				Dialect.Dialect dialect = _factory.Dialect;
				return literalType.ObjectToSQLString( _constantValue, dialect );
			}
			catch ( Exception t ) 
			{
				throw new QueryException( LiteralProcessor.ErrorCannotFormatLiteral + _constantExpression, t );
			}
		}

		public String GetRenderText(ISessionFactoryImplementor sessionFactory) 
		{
			IType type = _expectedType ?? _heuristicType;
			return ResolveToLiteralString( type );
		}
	}
}
