﻿using System;
using System.Collections;
using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Iesi.Collections.Generic;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.Hql.Ast.ANTLR.Util;
using NHibernate.Type;

namespace NHibernate.Hql.Ast.ANTLR
{
	public class QueryTranslatorImpl : IQueryTranslator
	{
		private Logger log = new Logger();
		private bool _shallowQuery;
		private bool _compiled;
		private string _queryIdentifier;
		private string _hql;
		private IDictionary<string, IFilter> _enabledFilters;
		private ISessionFactoryImplementor _factory;
		private IDictionary<string, string> _tokenReplacements;
		private CommonTokenStream _tokens;

		/// <summary>
		/// Creates a new AST-based query translator.
		/// </summary>
		/// <param name="queryIdentifier">The query-identifier (used in stats collection)</param>
		/// <param name="query">The hql query to translate</param>
		/// <param name="enabledFilters">Currently enabled filters</param>
		/// <param name="factory">The session factory constructing this translator instance.</param>
		public QueryTranslatorImpl(
				string queryIdentifier,
				string query,
				IDictionary<string, IFilter> enabledFilters,
				ISessionFactoryImplementor factory)
		{
			_queryIdentifier = queryIdentifier;
			_hql = query;
			_compiled = false;
			_shallowQuery = false;
			_enabledFilters = enabledFilters;
			_factory = factory;
		}

		/// <summary>
		/// Compile a "normal" query. This method may be called multiple
		/// times. Subsequent invocations are no-ops.
		/// </summary>
		/// <param name="replacements">Defined query substitutions.</param>
		/// <param name="shallow">Does this represent a shallow (scalar or entity-id) select?</param>
		public void Compile(IDictionary<string, string> replacements, bool shallow)
		{
			DoCompile( replacements, shallow, null );
		}

		public IList List(ISessionImplementor session, QueryParameters queryParameters)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable GetEnumerable(QueryParameters queryParameters, ISessionImplementor session)
		{
			throw new System.NotImplementedException();
		}

		public int ExecuteUpdate(QueryParameters queryParameters, ISessionImplementor session)
		{
			throw new System.NotImplementedException();
		}

		public string[][] GetColumnNames()
		{
			throw new System.NotImplementedException();
		}

		public IParameterTranslations GetParameterTranslations()
		{
			throw new System.NotImplementedException();
		}

		public ISet<string> QuerySpaces
		{
			get { throw new System.NotImplementedException(); }
		}

		public string SQLString
		{
			get { throw new System.NotImplementedException(); }
		}

		public IList<string> CollectSqlStrings
		{
			get { throw new System.NotImplementedException(); }
		}

		public string QueryString
		{
			get { return _hql; }
		}

		public IDictionary<string, IFilter> EnabledFilters
		{
			get { return _enabledFilters; }
		}

		public IType[] ReturnTypes
		{
			get { throw new System.NotImplementedException(); }
		}

		public string[] ReturnAliases
		{
			get { throw new System.NotImplementedException(); }
		}

		public bool ContainsCollectionFetches
		{
			get { throw new System.NotImplementedException(); }
		}

		public bool IsManipulationStatement
		{
			get { throw new System.NotImplementedException(); }
		}

		public bool IsShallowQuery
		{
			get { return _shallowQuery; }
		}

				/**
		 * Performs both filter and non-filter compiling.
		 *
		 * @param replacements   Defined query substitutions.
		 * @param shallow        Does this represent a shallow (scalar or entity-id) select?
		 * @param collectionRole the role name of the collection used as the basis for the filter, NULL if this
		 *                       is not a filter.
		 */
		private void DoCompile(IDictionary<string, string> replacements, bool shallow, String collectionRole) 
		{
			// If the query is already compiled, skip the compilation.
			if ( _compiled ) 
			{
				if ( log.isDebugEnabled() ) 
				{
					log.debug( "compile() : The query is already compiled, skipping..." );
				}
				return;
			}

			// Remember the parameters for the compilation.
			_tokenReplacements = replacements;
			if (_tokenReplacements == null ) {
				_tokenReplacements = new Dictionary<string, string>();
			}

			this._shallowQuery = shallow;

			try 
			{
				// PHASE 1 : Parse the HQL into an AST.
				ITree hqlAst = Parse( true );

				// PHASE 2 : Analyze the HQL AST, and produce an SQL AST.
				ITree sqlAst = Analyze( hqlAst, collectionRole );

				/*
				sqlAst = ( Statement ) w.getAST();

				// at some point the generate phase needs to be moved out of here,
				// because a single object-level DML might spawn multiple SQL DML
				// command executions.
				//
				// Possible to just move the sql generation for dml stuff, but for
				// consistency-sake probably best to just move responsiblity for
				// the generation phase completely into the delegates
				// (QueryLoader/StatementExecutor) themselves.  Also, not sure why
				// QueryLoader currently even has a dependency on this at all; does
				// it need it?  Ideally like to see the walker itself given to the delegates directly...

				if ( sqlAst.needsExecutor() ) {
					statementExecutor = buildAppropriateStatementExecutor( w );
				}
				else {
					// PHASE 3 : Generate the SQL.
					generate( ( QueryNode ) sqlAst );
					queryLoader = new QueryLoader( this, factory, w.getSelectClause() );
				}

				compiled = true;*/
			}/*
			catch ( QueryException qe ) {
				qe.setQueryString( hql );
				throw qe;
			}
			catch ( RecognitionException e ) {
				// we do not actually propogate ANTLRExceptions as a cause, so
				// log it here for diagnostic purposes
				if ( log.isTraceEnabled() ) {
					log.trace( "converted antlr.RecognitionException", e );
				}
				throw QuerySyntaxException.convert( e, hql );
			}
			catch ( ANTLRException e ) {
				// we do not actually propogate ANTLRExceptions as a cause, so
				// log it here for diagnostic purposes
				if ( log.isTraceEnabled() ) {
					log.trace( "converted antlr.ANTLRException", e );
				}
				throw new QueryException( e.getMessage(), hql );
			}
			*/
			finally {}

			_enabledFilters = null; //only needed during compilation phase...
		}

		/*
		private void generate(AST sqlAst) throws QueryException, RecognitionException {
			if ( sql == null ) {
				SqlGenerator gen = new SqlGenerator(factory);
				gen.statement( sqlAst );
				sql = gen.getSQL();
				if ( log.isDebugEnabled() ) {
					log.debug( "HQL: " + hql );
					log.debug( "SQL: " + sql );
				}
				gen.getParseErrorHandler().throwQueryException();
				collectedParameterSpecifications = gen.getCollectedParameters();
			}
		}
		*/
		private ITree Analyze(ITree hqlAst, string collectionRole)
		{
			CommonTreeNodeStream nodes = new CommonTreeNodeStream(hqlAst);
			nodes.TokenStream = _tokens;

			HqlSqlWalker w = new HqlSqlWalker( this, _factory, nodes, _tokenReplacements, collectionRole );
			w.TreeAdaptor = new HqlTreeAdaptor(w);

			Console.WriteLine(hqlAst.ToStringTree());

			// Transform the tree.
			ITree sqlAst = (ITree) w.statement().Tree;

			Console.WriteLine(sqlAst.ToStringTree());

			/*
			if ( AST_LOG.isDebugEnabled() ) {
				ASTPrinter printer = new ASTPrinter( SqlTokenTypes.class );
				AST_LOG.debug( printer.showAsString( w.getAST(), "--- SQL AST ---" ) );
			}
			*/

			w.ParseErrorHandler.ThrowQueryException();

			return sqlAst;
		}

		private ITree Parse(bool filter) 
		{
			// Parse the query string into an HQL AST.
			HqlLexer lex = new HqlLexer(new ANTLRStringStream(_hql));
			_tokens = new CommonTokenStream(lex);

			HqlParser parser = new HqlParser(_tokens);

			parser.Filter = filter;

			if ( log.isDebugEnabled() ) 
			{
				log.debug( "parse() - HQL: " + _hql );
			}

			ITree hqlAst = (ITree) parser.statement().Tree;

			JavaConstantConverter converter = new JavaConstantConverter();
			NodeTraverser walker = new NodeTraverser( converter );
			walker.TraverseDepthFirst( hqlAst );

			//showHqlAst( hqlAst );

			parser.ParseErrorHandler.ThrowQueryException();

			return hqlAst;
		}

		public class JavaConstantConverter : IVisitationStrategy
		{
			private ITree dotRoot;

			public void Visit(ITree node) 
			{
				if ( dotRoot != null ) 
				{
					// we are already processing a dot-structure
					if ( ASTUtil.IsSubtreeChild( dotRoot, node ) ) 
					{
						// ignore it...
						return;
					}
					else
					{
						// we are now at a new tree level
						dotRoot = null;
					}
				}

				if ( dotRoot == null && node.Type == HqlSqlWalker.DOT ) 
				{
					dotRoot = node;
					HandleDotStructure( (CommonTree) dotRoot );
				}
			}

			private static void HandleDotStructure(CommonTree dotStructureRoot) 
			{
				String expression = ASTUtil.GetPathText( dotStructureRoot );

				throw new NotImplementedException();
				/*
				Object constant = ReflectHelper.GetConstantValue( expression );
				
				if ( constant != null ) 
				{
					dotStructureRoot.Children.Clear();
					dotStructureRoot.SetType( HqlSqlWalker.JAVA_CONSTANT );
					dotStructureRoot.Token.Text = expression;
				}
				*/ 
			}
		}
	}
}