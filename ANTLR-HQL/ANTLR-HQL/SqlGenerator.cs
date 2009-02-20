using System;
using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR.Parameters;

namespace NHibernate.Hql.Ast.ANTLR
{
	/// <summary>
	/// Generates SQL by overriding callback methods in the base class, which does
	/// the actual SQL AST walking.
	/// Author: Joshua Davis, Steve Ebersole
	/// Ported By: Steve Strong
	/// </summary>
	public class SqlGenerator : IErrorReporter
	{
		/// <summary>
		/// Handles parser errors.
		/// </summary>
		private readonly IParseErrorHandler _parseErrorHandler;

		private ISessionFactoryImplementor _sessionFactory;

		public SqlGenerator(ISessionFactoryImplementor sfi)
		{
			_parseErrorHandler = new ErrorCounter();
			_sessionFactory = sfi;
		}

		public void ReportError(RecognitionException e)
		{
			_parseErrorHandler.ReportError(e); // Use the delegate.
		}

		public void ReportError(String s)
		{
			_parseErrorHandler.ReportError(s); // Use the delegate.
		}

		public void ReportWarning(String s)
		{
			_parseErrorHandler.ReportWarning(s);
		}

		public void SimpleExpr(ITree ast)
		{
			throw new NotImplementedException();
		}

		public string GetSQL()
		{
			throw new NotImplementedException();
		}

		public IList<IParameterSpecification> GetCollectedParameters()
		{
			throw new NotImplementedException();
		}
	}
}
