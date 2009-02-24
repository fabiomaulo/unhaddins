using System;
using System.Collections.Generic;
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using log4net;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR.Parameters;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.Hql.Ast.ANTLR.Util;

namespace NHibernate.Hql.Ast.ANTLR
{
	/// <summary>
	/// Generates SQL by overriding callback methods in the base class, which does
	/// the actual SQL AST walking.
	/// Author: Joshua Davis, Steve Ebersole
	/// Ported By: Steve Strong
	/// </summary>
	public partial class SqlGenerator : IErrorReporter
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(SqlGenerator));

		/// <summary>
		/// Handles parser errors.
		/// </summary>
		private readonly IParseErrorHandler _parseErrorHandler;

		private readonly ISessionFactoryImplementor _sessionFactory;

		private readonly List<IParameterSpecification> _collectedParameters = new List<IParameterSpecification>();

		/// <summary>
		/// the buffer resulting SQL statement is written to
		/// </summary>
		private readonly StringBuilder buf = new StringBuilder();

		public SqlGenerator(ISessionFactoryImplementor sfi) : base(null)
		{
			_parseErrorHandler = new ErrorCounter();
			_sessionFactory = sfi;
		}

		public SqlGenerator(ISessionFactoryImplementor sfi, ITreeNodeStream input) : this(input)
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

		public void SimpleExpr(IASTNode ast)
		{
			throw new NotImplementedException();
		}

		public string GetSQL()
		{
			return buf.ToString();
		}

		public IList<IParameterSpecification> GetCollectedParameters()
		{
			return _collectedParameters;
		}

		public IParseErrorHandler ParseErrorHandler
		{
			get { return _parseErrorHandler; }
		}

		private void Out(string s) 
		{
			buf.Append(s);
		}

		/**
		 * Returns the last character written to the output, or -1 if there isn't one.
		 */
		private int getLastChar() 
		{
			int len = buf.Length;
			if ( len == 0 )
				return -1;
			else
				return buf[len - 1];
		}

		/**
		 * Add a aspace if the previous token was not a space or a parenthesis.
		 */
		protected virtual void optionalSpace() 
		{
			// Implemented in the sub-class.
		}

		private void Out(IASTNode n) 
		{
			Out(n.Text);
		}

		private void separator(IASTNode n, String sep) 
		{
			if (n.RightHandSibling != null)
				Out(sep);
		}

		private bool  hasText(IASTNode a) 
		{
			return !string.IsNullOrEmpty(a.Text);
		}

		protected virtual void fromFragmentSeparator(IASTNode a) 
		{
			// moved this impl into the subclass...
		}

		protected virtual void nestedFromFragment(IASTNode d, IASTNode parent) 
		{
			// moved this impl into the subclass...
		}

		private StringBuilder getStringBuilder()
		{
			return buf;
		}

		private void nyi(IASTNode n) 
		{
			throw new InvalidOperationException("Unsupported node: " + n);
		}

		private void beginFunctionTemplate(IASTNode m, IASTNode i) 
		{
			// if template is null we just write the function out as it appears in the hql statement
			Out(i);
			Out("(");
		}

		private void endFunctionTemplate(IASTNode m) 
		{
			  Out(")");
		}

		private void commaBetweenParameters(String comma) 
		{
			Out(comma);
		}

	}
}
