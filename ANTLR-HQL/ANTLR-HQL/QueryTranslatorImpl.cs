﻿using System;
using System.Collections;
using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Iesi.Collections.Generic;
using log4net;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR.Loader;
using NHibernate.Hql.Ast.ANTLR.Parameters;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.Hql.Ast.ANTLR.Util;
using NHibernate.Type;
using NHibernate.Util;

namespace NHibernate.Hql.Ast.ANTLR
{
	public class QueryTranslatorImpl : IQueryTranslator
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(QueryTranslatorImpl));

		private bool _shallowQuery;
		private bool _compiled;
		private string _queryIdentifier;
		private readonly string _hql;
		private IDictionary<string, IFilter> _enabledFilters;
		private readonly ISessionFactoryImplementor _factory;
		private QueryLoader _queryLoader;
		private IParameterTranslations _paramTranslations;

		private HqlParseEngine _parser;
		private HqlSqlTranslator _translator;
		private HqlSqlGenerator _generator;

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
			return _translator.SqlStatement.Walker.SelectClause.ColumnNames;
		}

		public IParameterTranslations GetParameterTranslations()
		{
			if (_paramTranslations == null)
			{
				_paramTranslations = new ParameterTranslationsImpl(_translator.SqlStatement.Walker.Parameters);
			}
			return _paramTranslations;
		}

		public ISet<string> QuerySpaces
		{
			get { return _translator.SqlStatement.Walker.QuerySpaces; }
		}

		public string SQLString
		{
			get { return _generator.Sql; }
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
					list.Add(_generator.Sql);
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
				return _translator.SqlStatement.Walker.ReturnTypes;
			}
		}

		public string[] ReturnAliases
		{
			get
			{
				ErrorIfDML();
				return _translator.SqlStatement.Walker.ReturnAliases;
			}
		}

		public bool ContainsCollectionFetches
		{
			get { throw new System.NotImplementedException(); }
		}

		public bool IsManipulationStatement
		{
			get { return _translator.SqlStatement.NeedsExecutor; }
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
				if ( log.IsDebugEnabled ) 
				{
					log.Debug( "compile() : The query is already compiled, skipping..." );
				}
				return;
			}

			if (replacements == null) 
			{
				replacements = new Dictionary<string, string>();
			}

			_shallowQuery = shallow;

			try 
			{
				// PHASE 1 : Parse the HQL into an AST.
				_parser = new HqlParseEngine(_hql, true);
				_parser.Parse();

				// PHASE 2 : Analyze the HQL AST, and produce an SQL AST.
				_translator = new HqlSqlTranslator(_parser.Ast, _parser.Tokens, this, _factory, replacements,
                                                   collectionRole);
				_translator.Translate();
				
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

				if (_translator.SqlStatement.NeedsExecutor) 
				{
					throw new NotImplementedException();
//					statementExecutor = buildAppropriateStatementExecutor( w );
				}
				else 
				{
					// PHASE 3 : Generate the SQL.
					_generator = new HqlSqlGenerator(_translator.SqlStatement, _parser.Tokens, _factory);
					_generator.Generate();
					
					_queryLoader = new QueryLoader( this, _factory, _translator.SqlStatement.Walker.SelectClause );
				}

				_compiled = true;
			}
			catch ( QueryException qe ) 
			{
				qe.QueryString = _hql;
				throw;
			}
			catch ( RecognitionException e ) 
			{
				// we do not actually propogate ANTLRExceptions as a cause, so
				// log it here for diagnostic purposes
				if ( log.IsInfoEnabled ) 
				{
					log.Info( "converted antlr.RecognitionException", e );
				}
				throw QuerySyntaxException.Convert( e, _hql );
			}

			_enabledFilters = null; //only needed during compilation phase...
		}

		private void ErrorIfDML()
		{
			if (_translator.SqlStatement.NeedsExecutor)
			{
				throw new QueryExecutionRequestException("Not supported for DML operations", _hql);
			}
		}
	}

	public class HqlParseEngine
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(HqlParseEngine));

		private readonly string _hql;
		private CommonTokenStream _tokens;
		private readonly bool _filter;
		private IASTNode _ast;

		public HqlParseEngine(string hql, bool filter)
		{
			_hql = hql;
			_filter = filter;
		}

		public string Hql
		{
			get { return _hql; }
		}

		public IASTNode Ast
		{
			get { return _ast; }
		}

		public CommonTokenStream Tokens
		{
			get { return _tokens; }
		}

		public void Parse()
		{
			if (_ast == null)
			{
				// Parse the query string into an HQL AST.
				HqlLexer lex = new HqlLexer(new CaseInsensitiveStringStream(_hql));
				_tokens = new CommonTokenStream(lex);

				HqlParser parser = new HqlParser(_tokens);
				parser.TreeAdaptor = new ASTTreeAdaptor();

				parser.Filter = _filter;

				if (log.IsDebugEnabled)
				{
					log.Debug("parse() - HQL: " + _hql);
				}

				_ast = (IASTNode) parser.statement().Tree;

				NodeTraverser walker = new NodeTraverser(new ConstantConverter());
				walker.TraverseDepthFirst(_ast);

				//showHqlAst( hqlAst );

				parser.ParseErrorHandler.ThrowQueryException();
			}
		}

		class ConstantConverter : IVisitationStrategy
		{
			private IASTNode dotRoot;

			public void Visit(IASTNode node)
			{
				if (dotRoot != null)
				{
					// we are already processing a dot-structure
					if (ASTUtil.IsSubtreeChild(dotRoot, node))
					{
						// ignore it...
						return;
					}

					// we are now at a new tree level
					dotRoot = null;
				}

				if (dotRoot == null && node.Type == HqlSqlWalker.DOT)
				{
					dotRoot = node;
					HandleDotStructure(dotRoot);
				}
			}

			private static void HandleDotStructure(IASTNode dotStructureRoot)
			{
				String expression = ASTUtil.GetPathText(dotStructureRoot);

				object constant = GetConstantValue(expression );
				
				if ( constant != null ) 
				{
					dotStructureRoot.ClearChildren();
					dotStructureRoot.Type = HqlSqlWalker.JAVA_CONSTANT;
					dotStructureRoot.Text = expression;
				}
			}

			private static object GetConstantValue(string qualifiedName)
			{
				string className = StringHelper.Qualifier(qualifiedName);

				if (!string.IsNullOrEmpty(className))
				{
					System.Type t = System.Type.GetType(className);

					if (t != null)
					{
						return ReflectHelper.GetConstantValue(t, StringHelper.Unqualify(qualifiedName));
					}
				}

				return null;
			}
		}

	}

	public class HqlSqlTranslator
	{
		private readonly IASTNode _inputAst;
		private readonly CommonTokenStream _tokens;
		private readonly QueryTranslatorImpl _qti;
		private readonly ISessionFactoryImplementor _sfi;
		private readonly IDictionary<string, string> _tokenReplacements;
		private readonly string _collectionRole;
		private IStatement _resultAst;

		public HqlSqlTranslator(IASTNode ast, CommonTokenStream tokens, QueryTranslatorImpl qti, ISessionFactoryImplementor sfi, IDictionary<string, string> tokenReplacements, string collectionRole)
		{
			_inputAst = ast;
			_tokens = tokens;
			_qti = qti;
			_sfi = sfi;
			_tokenReplacements = tokenReplacements;
			_collectionRole = collectionRole;
		}

		public IASTNode HqlAst
		{
			get { return _inputAst; }
		}

		public IStatement SqlStatement
		{
			get { return _resultAst; }
		}

		public IStatement Translate()
		{
			if (_resultAst == null)
			{
				CommonTreeNodeStream nodes = new CommonTreeNodeStream(_inputAst);
				nodes.TokenStream = _tokens;

				HqlSqlWalker hqlSqlWalker = new HqlSqlWalker(_qti, _sfi, nodes, _tokenReplacements, _collectionRole);
				hqlSqlWalker.TreeAdaptor = new HqlSqlWalkerTreeAdaptor(hqlSqlWalker);

				// TODO - debug, remove
				Console.WriteLine(_inputAst.ToStringTree());

				// Transform the tree.
				_resultAst = (IStatement) hqlSqlWalker.statement().Tree;

				// TODO - debug, remove
				Console.WriteLine(((IASTNode) _resultAst).ToStringTree());

				/*
				if ( AST_LOG.isDebugEnabled() ) {
					ASTPrinter printer = new ASTPrinter( SqlTokenTypes.class );
					AST_LOG.debug( printer.showAsString( w.getAST(), "--- SQL AST ---" ) );
				}
				*/

				hqlSqlWalker.ParseErrorHandler.ThrowQueryException();
			}

			return _resultAst;
		}
	}

	public class HqlSqlGenerator
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(HqlSqlGenerator));

		private readonly IASTNode _ast;
		private readonly CommonTokenStream _tokens;
		private readonly ISessionFactoryImplementor _sfi;
		private string _sql;
		private IList<IParameterSpecification> _parameters;

		public HqlSqlGenerator(IStatement ast, CommonTokenStream tokens, ISessionFactoryImplementor sfi)
		{
			_ast = (IASTNode) ast;
			_tokens = tokens;
			_sfi = sfi;
		}

		public string Sql
		{
			get { return _sql; }
		}

		public IList<IParameterSpecification> CollectionParameters
		{
			get { return _parameters; }
		}

		public string Generate()
		{
			if (_sql == null)
			{
				CommonTreeNodeStream nodes = new CommonTreeNodeStream(_ast);
				nodes.TokenStream = _tokens;

				SqlGenerator gen = new SqlGenerator(_sfi, nodes);
				gen.TreeAdaptor = new ASTTreeAdaptor();

				gen.statement();

				_sql = gen.GetSQL();

				if (log.IsDebugEnabled)
				{
					log.Debug("SQL: " + _sql);
				}

				gen.ParseErrorHandler.ThrowQueryException();

				_parameters = gen.GetCollectedParameters();
			}

			return _sql;
		}
	}
}
