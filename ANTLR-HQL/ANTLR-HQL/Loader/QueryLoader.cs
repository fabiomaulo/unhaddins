using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.Impl;
using NHibernate.Loader;
using NHibernate.Persister.Collection;
using NHibernate.Persister.Entity;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using NHibernate.Type;
using NHibernate.Util;
using IQueryable=NHibernate.Persister.Entity.IQueryable;

namespace NHibernate.Hql.Ast.ANTLR.Loader
{
	public class QueryLoader : BasicLoader
	{
		private IQueryTranslator _queryTranslator;
		private SelectClause _selectClause;

		private bool _hasScalars;
		private string[][] _scalarColumnNames;
		private IType[] _queryReturnTypes;
		private IResultTransformer _selectNewTransformer;
		private string[] _queryReturnAliases;
		private IQueryableCollection[] _collectionPersisters;
		private int[] _collectionOwners;
		private string[] _collectionSuffixes;
		private IQueryable[] _entityPersisters;
		private bool[] _entityEagerPropertyFetches;
		private string[] _entityAliases;
		private string[] _sqlAliases;
		private string[] _sqlAliasSuffixes;
		private bool[] _includeInSelect;
		private int[] _owners;
		private EntityType[] _ownerAssociationTypes;
		private readonly Dictionary<string, string> _sqlAliasByEntityAlias= new Dictionary<string, string>(8);
		private int _selectLength;
		private LockMode[] _defaultLockModes;

		public QueryLoader(IQueryTranslator queryTranslator, ISessionFactoryImplementor factory, SelectClause selectClause) : base(factory)
		{
			_queryTranslator = queryTranslator;
			_selectClause = selectClause;

			Initialize(selectClause);
			PostInstantiate();
		}

		protected override LockMode[] GetLockModes(IDictionary<string, LockMode> lockModes)
		{
			throw new System.NotImplementedException();
		}

		protected override SqlString SqlString
		{
			get { return new SqlString(_queryTranslator.SQLString); }
		}

		protected override ILoadable[] EntityPersisters
		{
			get { return _entityPersisters; }
		}

		protected override string[] Suffixes
		{
			get { return _sqlAliasSuffixes; }
		}

		protected override string[] CollectionSuffixes
		{
			get { return _collectionSuffixes; }
		}

		private void Initialize(SelectClause selectClause)
		{
			IList<FromElement> fromElementList = selectClause.FromElementsForLoad;

			_hasScalars = selectClause.IsScalarSelect;
			_scalarColumnNames = selectClause.ColumnNames;
			//sqlResultTypes = selectClause.getSqlResultTypes();
			_queryReturnTypes = selectClause.QueryReturnTypes;

			_selectNewTransformer = HolderInstantiator.CreateSelectNewTransformer(
					selectClause.Constructor,
					selectClause.IsMap);
			
			// TODO - Java implementation passes IsList into CreateSelectNewTransformer...,
			//		selectClause.IsList);

			_queryReturnAliases = selectClause.QueryReturnAliases;

			IList<FromElement> collectionFromElements = selectClause.CollectionFromElements;
			if ( collectionFromElements != null && collectionFromElements.Count !=0 )
			{
				int length = collectionFromElements.Count;
				_collectionPersisters = new IQueryableCollection[length];
				_collectionOwners = new int[length];
				_collectionSuffixes = new string[length];

				for ( int i=0; i<length; i++ ) 
				{
					FromElement collectionFromElement = (FromElement) collectionFromElements[i];
					_collectionPersisters[i] = collectionFromElement.QueryableCollection;
					_collectionOwners[i] = fromElementList.IndexOf(collectionFromElement.Origin);
	//				collectionSuffixes[i] = collectionFromElement.getColumnAliasSuffix();
	//				collectionSuffixes[i] = Integer.toString( i ) + "_";
					_collectionSuffixes[i] = collectionFromElement.CollectionSuffix;
				}
			}

			int size = fromElementList.Count;
			_entityPersisters = new IQueryable[size];
			_entityEagerPropertyFetches = new bool[size];
			_entityAliases = new String[size];
			_sqlAliases = new String[size];
			_sqlAliasSuffixes = new String[size];
			_includeInSelect = new bool[size];
			_owners = new int[size];
			_ownerAssociationTypes = new EntityType[size];

			for ( int i = 0; i < size; i++ ) 
			{
				FromElement element = fromElementList[i];
				_entityPersisters[i] = ( IQueryable ) element.EntityPersister;

				if ( _entityPersisters[i] == null )
				{
					throw new InvalidOperationException( "No entity persister for " + element.ToString() );
				}

				_entityEagerPropertyFetches[i] = element.IsAllPropertyFetch;
				_sqlAliases[i] = element.TableAlias;
				_entityAliases[i] = element.ClassAlias;
				_sqlAliasByEntityAlias.Add( _entityAliases[i], _sqlAliases[i] );
				// TODO should we just collect these like with the collections above?
				_sqlAliasSuffixes[i] = ( size == 1 ) ? "" : i.ToString() + "_";
	//			sqlAliasSuffixes[i] = element.getColumnAliasSuffix();
				_includeInSelect[i] = !element.IsFetch;
				if ( _includeInSelect[i] ) 
				{
					_selectLength++;
				}

				_owners[i] = -1; //by default
				if ( element.IsFetch ) 
				{
					if ( element.IsCollectionJoin  || element.QueryableCollection != null ) 
					{
						// This is now handled earlier in this method.
					}
					else if ( element.DataType.IsEntityType ) 
					{
						EntityType entityType = ( EntityType ) element.DataType;
						if ( entityType.IsOneToOne) 
						{
							_owners[i] = fromElementList.IndexOf( element.Origin );
						}
						_ownerAssociationTypes[i] = entityType;
					}
				}
			}

			//NONE, because its the requested lock mode, not the actual! 
			_defaultLockModes = ArrayHelper.FillArray(LockMode.None, size);
		}

		internal IEnumerable GetEnumerable(QueryParameters queryParameters, ISessionImplementor session)
		{
			bool statsEnabled = session.Factory.Statistics.IsStatisticsEnabled;

			var stopWath = new Stopwatch();
			if (statsEnabled)
			{
				stopWath.Start();
			}

			IDbCommand cmd = PrepareQueryCommand(queryParameters, false, session);

			// This IDataReader is disposed of in EnumerableImpl.Dispose
			IDataReader rs = GetResultSet(cmd, queryParameters.HasAutoDiscoverScalarTypes, false, queryParameters.RowSelection, session);

			HolderInstantiator hi =
				HolderInstantiator.GetHolderInstantiator(_selectNewTransformer, queryParameters.ResultTransformer, _queryReturnAliases);

			IEnumerable result =
				new EnumerableImpl(rs, cmd, session, _queryTranslator.ReturnTypes, _queryTranslator.GetColumnNames(), queryParameters.RowSelection, hi);

			if (statsEnabled)
			{
				stopWath.Stop();
				session.Factory.StatisticsImplementor.QueryExecuted("HQL: " + _queryTranslator.QueryString, 0, stopWath.Elapsed);
				// NH: Different behavior (H3.2 use QueryLoader in AST parser) we need statistic for orginal query too.
				// probably we have a bug some where else for statistic RowCount
				session.Factory.StatisticsImplementor.QueryExecuted(QueryIdentifier, 0, stopWath.Elapsed);
			}
			return result;
		}
	}
}
