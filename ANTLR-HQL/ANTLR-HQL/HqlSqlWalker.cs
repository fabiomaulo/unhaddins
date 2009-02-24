using System;
using System.Collections.Generic;
using Antlr.Runtime.Tree;
using Iesi.Collections.Generic;
using log4net;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR.Parameters;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.Hql.Ast.ANTLR.Util;
using NHibernate.Persister.Collection;
using NHibernate.SqlCommand;
using NHibernate.Type;

namespace NHibernate.Hql.Ast.ANTLR
{
	public partial class HqlSqlWalker
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(HqlSqlWalker));


		// Fields
		private readonly string _collectionFilterRole;
		private readonly SessionFactoryHelperExtensions _sessionFactoryHelper;
		private readonly QueryTranslatorImpl _qti;
		private int _currentTopLevelClauseType;
		private int _currentClauseType;
		private int _level;
		private bool _inSelect;
		private bool _inFrom;
		private bool _inFunctionCall;
		private bool _inCase;
		private int _statementType;
		private int _currentStatementType;
		private string _statementTypeName;
		private int _positionalParameterCount;
		private readonly List<IParameterSpecification> _parameters = new List<IParameterSpecification>();
		private FromClause _currentFromClause;
		private SelectClause _selectClause;
		private readonly AliasGenerator _aliasGenerator = new AliasGenerator();

		private readonly Set<string> _querySpaces = new HashedSet<string>();

		private readonly ITreeNodeStream _hqlParser;

		private readonly LiteralProcessor _literalProcessor;

		private readonly IDictionary<string, string> _tokenReplacements;

		private JoinType _impliedJoinType;

		private IParseErrorHandler _parseErrorHandler = new ErrorCounter();

		private string[][] columnNames;

		private IASTFactory _nodeFactory;

		public HqlSqlWalker(QueryTranslatorImpl qti,
					  ISessionFactoryImplementor sfi,
					  ITreeNodeStream input, 
					  IDictionary<string, string> tokenReplacements,
					  string collectionRole)
			: this(input)
		{
			_sessionFactoryHelper = new SessionFactoryHelperExtensions(sfi);
			_qti = qti;
			_hqlParser = input;
			_literalProcessor = new LiteralProcessor(this);
			_tokenReplacements = tokenReplacements;
			_collectionFilterRole = collectionRole;
		}

		public IParseErrorHandler ParseErrorHandler
		{
			get { return _parseErrorHandler; }
			set { _parseErrorHandler = value; }
		}

		public AliasGenerator AliasGenerator
		{
			get { return _aliasGenerator; }
		}

		public Set<string> QuerySpaces
		{
			get { return _querySpaces; }
		}

		public SessionFactoryHelperExtensions SessionFactoryHelper
		{
			get { return _sessionFactoryHelper; }
		}
		
		public int CurrentStatementType
		{
			get { return _currentStatementType; }
		}

		public JoinType ImpliedJoinType
		{
			get { return _impliedJoinType; }
		}

		public String[] ReturnAliases
		{
			get { return _selectClause.QueryReturnAliases; }
		}

		public IType[] ReturnTypes
		{
			get { return _selectClause.QueryReturnTypes; }	
		}

		public string CollectionFilterRole
		{
			get { return _collectionFilterRole; }	
		}

		public SelectClause SelectClause
		{
			get { return _selectClause; }
		}

		public IList<IParameterSpecification> Parameters
		{
			get { return _parameters; }
		}

		void beforeStatement(string statementName, int statementType)
		{
			_inFunctionCall = false;
			_level++;
			if (_level == 1)
			{
				_statementTypeName = statementName;
				_statementType = statementType;
			}
			_currentStatementType = statementType;
			if (log.IsDebugEnabled)
			{
				log.Debug(statementName + " << begin [level=" + _level + ", statement=" + _statementTypeName + "]");
			}
		}

		void beforeStatementCompletion(string statementName)
		{
			if (log.IsDebugEnabled)
			{
				log.Debug(statementName + " : finishing up [level=" + _level + ", statement=" + _statementTypeName + "]");
			}
		}

		void prepareVersioned(object o1, object o2)
		{
			throw new NotImplementedException();
		}

		void postProcessUpdate(object o1)
		{
			throw new NotImplementedException();
		}

		void postProcessDelete(object o1)
		{
			throw new NotImplementedException();
		}

		void postProcessInsert(object o1)
		{
			throw new NotImplementedException();
		}

		void afterStatementCompletion(string statementName)
		{
			if (log.IsDebugEnabled)
			{
				log.Debug(statementName + " >> end [level=" + _level + ", statement=" + _statementTypeName + "]");
			}
			_level--;
		}

		void handleClauseStart(int clauseType)
		{
			_currentClauseType = clauseType;
			if (_level == 1)
			{
				_currentTopLevelClauseType = clauseType;
			}
		}

		object createIntoClause(object o1, object o2)
		{
			throw new NotImplementedException();
		}

		IASTNode resolve(IASTNode node)
		{
			if (node != null)
			{
				// This is called when it's time to fully resolve a path expression.
				IResolvableNode r = (IResolvableNode)node;

				if (_inFunctionCall)
				{
					r.ResolveInFunctionCall(false, true);
				}
				else
				{
					r.Resolve(false, true);	// Generate implicit joins, only if necessary.
				}
			}

			return node;
		}

		void processQuery(IASTNode select, IASTNode query)
		{
			if ( log.IsDebugEnabled ) {
				log.Debug( "processQuery() : " + query.ToStringTree() );
			}

			try {
				QueryNode qn = ( QueryNode ) query;

				// Was there an explicit select expression?
				bool explicitSelect = select != null && select.ChildCount > 0;

				if ( !explicitSelect ) {
					// No explicit select expression; render the id and properties
					// projection lists for every persister in the from clause into
					// a single 'token node'.
					//TODO: the only reason we need this stuff now is collection filters,
					//      we should get rid of derived select clause completely!
					CreateSelectClauseFromFromClause( qn );
				}
				else {
					// Use the explicitly declared select expression; determine the
					// return types indicated by each select token
					UseSelectClause( select );
				}

				// After that, process the JOINs.
				// Invoke a delegate to do the work, as this is farily complex.
				JoinProcessor joinProcessor = new JoinProcessor( this );
				joinProcessor.ProcessJoins( qn );

				// Attach any mapping-defined "ORDER BY" fragments
				foreach (FromElement fromElement in qn.FromClause.GetProjectionList())
				{
					if ( fromElement.IsFetch && fromElement.QueryableCollection != null ) 
					{
						// Does the collection referenced by this FromElement
						// specify an order-by attribute?  If so, attach it to
						// the query's order-by
						if ( fromElement.QueryableCollection.HasOrdering) 
						{
							string orderByFragment = fromElement
									.QueryableCollection
									.GetSQLOrderByString( fromElement.TableAlias );
							qn.GetOrderByClause().AddOrderFragment( orderByFragment );
						}
						if ( fromElement.QueryableCollection.HasManyToManyOrdering ) 
						{
							string orderByFragment = fromElement.QueryableCollection
									.GetManyToManyOrderByString( fromElement.TableAlias );
							qn.GetOrderByClause().AddOrderFragment( orderByFragment );
						}
					}
				}
			}
			finally
			{
				PopFromClause();
			}
		}

		private void UseSelectClause(IASTNode select)
		{
			_selectClause = (SelectClause) select;
			_selectClause.InitializeExplicitSelectClause(_currentFromClause);
		}

		private void CreateSelectClauseFromFromClause(IASTNode qn)
		{
			// TODO - check this.  Not *exactly* the same logic as the Java original
			qn.InsertChild(0, (IASTNode)adaptor.Create(SELECT_CLAUSE, "{derived select clause}"));

			_selectClause = ( SelectClause ) qn.GetChild(0);
			_selectClause.InitializeDerivedSelectClause( _currentFromClause );

			if ( log.IsDebugEnabled ) 
			{
				log.Debug( "Derived SELECT clause created." );
			}
		}

		/// <summary>
		/// Returns to the previous 'FROM' context.
		/// </summary>
		private void PopFromClause()
		{
			_currentFromClause = _currentFromClause.ParentFromClause;
		}

		void processConstructor(object o1)
		{
			throw new NotImplementedException();
		}

		void evaluateAssignment(object o)
		{
			throw new NotImplementedException();
		}

		void beforeSelectClause()
		{
			throw new NotImplementedException();
		}

		void setAlias(object o1, object o2)
		{
			throw new NotImplementedException();
		}

		void resolveSelectExpression(object o1)
		{
			throw new NotImplementedException();
		}

		void PrepareFromClauseInputTree(IASTNode fromClauseInput )
		{
			if (isFilter())
			{
				// Handle collection-fiter compilation.
				// IMPORTANT NOTE: This is modifying the INPUT (HQL) tree, not the output tree!
				IQueryableCollection persister = _sessionFactoryHelper.GetCollectionPersister(_collectionFilterRole);
				IType collectionElementType = persister.ElementType;
				if (!collectionElementType.IsEntityType)
				{
					throw new QueryException("collection of values in filter: this");
				}

				string collectionElementEntityName = persister.ElementPersister.EntityName;

				IASTNode fromElement = (IASTNode)adaptor.Create(FILTER_ENTITY, collectionElementEntityName);
				IASTNode alias = (IASTNode)adaptor.Create(ALIAS, "this");

				fromClauseInput.AddChild(fromElement);
				fromClauseInput.AddChild(alias);

				// Show the modified AST.
				if (log.IsDebugEnabled)
				{
					log.Debug("prepareFromClauseInputTree() : Filter - Added 'this' as a from element...");
				}
				
				// Create a parameter specification for the collection filter...
				IType collectionFilterKeyType = _sessionFactoryHelper.RequireQueryableCollection(_collectionFilterRole).KeyType;
				ParameterNode collectionFilterKeyParameter = (ParameterNode)adaptor.Create(PARAM, "?");
				CollectionFilterKeyParameterSpecification collectionFilterKeyParameterSpec = new CollectionFilterKeyParameterSpecification(
						_collectionFilterRole, collectionFilterKeyType, _positionalParameterCount++
				);
				collectionFilterKeyParameter.HqlParameterSpecification = collectionFilterKeyParameterSpec;
				_parameters.Add(collectionFilterKeyParameterSpec);
			}
		}

		object createFromElement(object o1, object o2)
		{
			throw new NotImplementedException();
		}

		object createFromJoinElement(object o1, object o2, object o3, object o4, object o5, object o6)
		{
			throw new NotImplementedException();
		}


		IASTNode createFromElement(string path, IASTNode alias, IASTNode propertyFetch)
		{
			FromElement fromElement = _currentFromClause.AddFromElement( path, alias );
			fromElement.SetAllPropertyFetch(propertyFetch != null);
			return fromElement;
		}


		object createFromFilterElement(object o1, object o2)
		{
			throw new NotImplementedException();
		}

		void setImpliedJoinType(object o1)
		{
			throw new NotImplementedException();
		}

		void PushFromClause(IASTNode fromNode, IASTNode inputFromNode)
		{
			FromClause newFromClause = (FromClause)fromNode;
			newFromClause.SetParentFromClause(_currentFromClause);
			_currentFromClause = newFromClause;
		}

		void prepareArithmeticOperator(object o1)
		{
			throw new NotImplementedException();
		}

		void processFunction(object o1)
		{
			throw new NotImplementedException();
		}

		void processFunction(object o1, object o2)
		{
			throw new NotImplementedException();
		}

		void processbool(object o1)
		{
			throw new NotImplementedException();
		}

		void prepareLogicOperator(IASTNode operatorNode)
		{
			( ( IOperatorNode ) operatorNode ).Initialize(this);
		}

		void processNumericLiteral(IASTNode literal)
		{
			_literalProcessor.ProcessNumericLiteral((SqlNode) literal);
		}

		protected IASTNode lookupProperty(IASTNode dot, bool root, bool inSelect)
		{
			DotNode dotNode = ( DotNode ) dot;
			FromReferenceNode lhs = dotNode.GetLhs();
			IASTNode rhs = lhs.RightHandSibling;
			switch ( rhs.Type ) {
				case ELEMENTS:
				case INDICES:
					if ( log.IsDebugEnabled ) 
					{
						log.Debug( "lookupProperty() " + dotNode.Path + " => " + rhs.Text + "(" + lhs.Path + ")" );
					}

					CollectionFunction f = ( CollectionFunction ) rhs;
					// Re-arrange the tree so that the collection function is the root and the lhs is the path.

					f.ClearChildren();
					f.AddChild(lhs);
					lhs.ClearChildren();
					dotNode.ClearChildren();
					dotNode.AddChild(f);
					/*
					f.setFirstChild( lhs );
					lhs.setNextSibling( null );
					dotNode.setFirstChild( f );
					*/
					resolve( lhs );			// Don't forget to resolve the argument!
					f.Resolve( inSelect );	// Resolve the collection function now.
					return f;
				default:
					// Resolve everything up to this dot, but don't resolve the placeholders yet.
					dotNode.ResolveFirstChild();
					return dotNode;
			}
		}

		object processIndex(object o1)
		{
			throw new NotImplementedException();
		}

		bool isNonQualifiedPropertyRef(IASTNode ident)
		{
			string identText = ident.Text;

			if ( _currentFromClause.IsFromElementAlias( identText ) ) 
			{
				return false;
			}

			IList<IASTNode> fromElements = _currentFromClause.GetExplicitFromElements();
			if ( fromElements.Count == 1 ) 
			{
				FromElement fromElement = (FromElement) fromElements[0];
				try 
				{
					log.Info( "attempting to resolve property [" + identText + "] as a non-qualified ref" );
					return fromElement.GetPropertyMapping(identText).ToType(identText) != null;
				}
				catch( QueryException ) 
				{
					// Should mean that no such property was found
				}
			}

			return false;
		}

		object lookupNonQualifiedProperty(object o1)
		{
			throw new NotImplementedException();
		}

		void lookupAlias(object o1)
		{
			throw new NotImplementedException();
		}

		object generateNamedParameter(object o1, object o2)
		{
			throw new NotImplementedException();
		}

		object generatePositionalParameter(object o1)
		{
			throw new NotImplementedException();
		}

		public FromClause CurrentFromClause
		{
			get { return _currentFromClause; }
		}

		public int StatementType 
		{
			get { return _statementType; }
		}

		public LiteralProcessor LiteralProcessor
		{
			get { return _literalProcessor; }
		}

		public int CurrentClauseType
		{
				get { return _currentClauseType; }
		}

		public IDictionary<string, IFilter> EnabledFilters
		{
			get { return _qti.EnabledFilters; }
		}

		public bool IsSubQuery
		{
			get { return _level > 1; }
		}

		public bool IsSelectStatement
		{
			get { return _statementType == SELECT; }
		}

		public bool IsInFrom
		{
			get { return _inFrom; }
		}

		public bool IsInSelect
		{
				get { return _inSelect; }
		}

		public IDictionary<string, string> TokenReplacements
		{
			get { return _tokenReplacements; }
		}

		public bool IsComparativeExpressionClause
		{
			get
			{
				// Note: once we add support for "JOIN ... ON ...",
				// the ON clause needs to get included here
				return CurrentClauseType == WHERE ||
					   CurrentClauseType == WITH ||
					   IsInCase;
			}
		}

		public bool IsInCase
		{
			get { return _inCase; }
		}

		public bool IsShallowQuery
		{
			get 
			{
				// select clauses for insert statements should alwasy be treated as shallow
				return StatementType == INSERT ||  _qti.IsShallowQuery;
			}
		}

		public FromClause GetFinalFromClause()
		{
			FromClause top = _currentFromClause;
			while (top.ParentFromClause != null)
			{
				top = top.ParentFromClause;
			}
			return top;
		}


		// Helper methods

		public bool isFilter()
		{
			return _collectionFilterRole != null;
		}

		public IASTFactory ASTFactory
		{
			get
			{
				if (_nodeFactory == null)
				{
					_nodeFactory = new ASTFactory(adaptor);
				}

				return _nodeFactory;
			}
		}

		public void AddQuerySpaces(string[] spaces)
		{
			for (int i = 0; i < spaces.Length; i++)
			{
				_querySpaces.Add(spaces[i]);
			}
		}

	}
}
