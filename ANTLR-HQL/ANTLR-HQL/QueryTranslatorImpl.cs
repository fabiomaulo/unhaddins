using System;
using System.Collections;
using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Iesi.Collections.Generic;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR.Loader;
using NHibernate.Hql.Ast.ANTLR.Parameters;
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
		private readonly string _hql;
		private string _sql;
		private IDictionary<string, IFilter> _enabledFilters;
		private readonly ISessionFactoryImplementor _factory;
		private IDictionary<string, string> _tokenReplacements;
		private CommonTokenStream _tokens;
		private IList<IParameterSpecification> _collectedParameterSpecifications;
		private QueryLoader _queryLoader;
		private IStatement _sqlAst;
		private IParameterTranslations _paramTranslations;

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
			ErrorIfDML();
			return _queryLoader.GetEnumerable(queryParameters, session);
		}

		public int ExecuteUpdate(QueryParameters queryParameters, ISessionImplementor session)
		{
			throw new System.NotImplementedException();
		}

		public string[][] GetColumnNames()
		{
			ErrorIfDML();
			return _sqlAst.Walker.SelectClause.ColumnNames;
		}

		public IParameterTranslations GetParameterTranslations()
		{
			if (_paramTranslations == null)
			{
				_paramTranslations = new ParameterTranslationsImpl(_sqlAst.Walker.Parameters);
			}
			return _paramTranslations;
		}

		public ISet<string> QuerySpaces
		{
			get { return _sqlAst.Walker.QuerySpaces; }
		}

		public string SQLString
		{
			get { return _sql; }
		}

		public IList<string> CollectSqlStrings
		{
			get
			{
				List<string> list = new List<string>();
				if (IsManipulationStatement)
				{
					throw new NotImplementedException();
					/*
					String[] sqlStatements = statementExecutor.getSqlStatements();
					for (int i = 0; i < sqlStatements.length; i++)
					{
						list.Add(sqlStatements[i]);
					}
					*/
				}
				else
				{
					list.Add(_sql);
				}
				return list;
			}
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
			get
			{
				ErrorIfDML();
				return _sqlAst.Walker.ReturnTypes;
			}
		}

		public string[] ReturnAliases
		{
			get
			{
				ErrorIfDML();
				return _sqlAst.Walker.ReturnAliases;
			}
		}

		public bool ContainsCollectionFetches
		{
			get { throw new System.NotImplementedException(); }
		}

		public bool IsManipulationStatement
		{
			get { return _sqlAst.NeedsExecutor; }
		}

		public bool IsShallowQuery
		{
			get { return _shallowQuery; }
		}

		/// <summary>
		/// Performs both filter and non-filter compiling.
		/// </summary>
		/// <param name="replacements">Defined query substitutions.</param>
		/// <param name="shallow">Does this represent a shallow (scalar or entity-id) select?</param>
		/// <param name="collectionRole">the role name of the collection used as the basis for the filter, NULL if this is not a filter.</param>
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

			_shallowQuery = shallow;

			try 
			{
				// PHASE 1 : Parse the HQL into an AST.
				ITree hqlAst = Parse( true );

				// PHASE 2 : Analyze the HQL AST, and produce an SQL AST.
				_sqlAst = Analyze(hqlAst, collectionRole);
				
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

				if ( _sqlAst.NeedsExecutor) 
				{
					throw new NotImplementedException();
//					statementExecutor = buildAppropriateStatementExecutor( w );
				}
				else 
				{
					// PHASE 3 : Generate the SQL.
					Generate( _sqlAst );
					_queryLoader = new QueryLoader( this, _factory, _sqlAst.Walker.SelectClause );
				}

				_compiled = true;
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

		private void Generate(IStatement sqlAst)
		{
			if ( _sql == null ) 
			{
				CommonTreeNodeStream nodes = new CommonTreeNodeStream(sqlAst);
				nodes.TokenStream = _tokens;

				SqlGenerator gen = new SqlGenerator(_factory, nodes);

				gen.statement();

				_sql = gen.GetSQL();

				if ( log.isDebugEnabled() ) {
					log.debug( "HQL: " + _hql );
					log.debug( "SQL: " + _sql );
				}
				gen.ParseErrorHandler.ThrowQueryException();

				_collectedParameterSpecifications = gen.GetCollectedParameters();
			}
		}

		private IStatement Analyze(ITree hqlAst, string collectionRole)
		{
			CommonTreeNodeStream nodes = new CommonTreeNodeStream(hqlAst);
			nodes.TokenStream = _tokens;

			HqlSqlWalker hqlSqlWalker = new HqlSqlWalker(this, _factory, nodes, _tokenReplacements, collectionRole);
			hqlSqlWalker.TreeAdaptor = new HqlTreeAdaptor(hqlSqlWalker);

			// TODO - debug, remove
			Console.WriteLine(hqlAst.ToStringTree());

			// Transform the tree.
			IStatement sqlAst = (IStatement)hqlSqlWalker.statement().Tree;

			// TODO - debug, remove
			Console.WriteLine(((ITree)sqlAst).ToStringTree());

			/*
			if ( AST_LOG.isDebugEnabled() ) {
				ASTPrinter printer = new ASTPrinter( SqlTokenTypes.class );
				AST_LOG.debug( printer.showAsString( w.getAST(), "--- SQL AST ---" ) );
			}
			*/

			hqlSqlWalker.ParseErrorHandler.ThrowQueryException();
		
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

		private void ErrorIfDML()
		{
			if (_sqlAst.NeedsExecutor)
			{
				throw new QueryExecutionRequestException("Not supported for DML operations", _hql);
			}
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
