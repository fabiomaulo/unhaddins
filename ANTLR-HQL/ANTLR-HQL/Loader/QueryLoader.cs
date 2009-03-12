using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using NHibernate.Engine;
using NHibernate.Hql.Ast.ANTLR.Tree;
using NHibernate.Hql.Ast.ANTLR.Util;
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
		private readonly QueryTranslatorImpl _queryTranslator;
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
		private readonly NullableDictionary<string, string> _sqlAliasByEntityAlias= new NullableDictionary<string, string>();
		private int _selectLength;
		private LockMode[] _defaultLockModes;

		public QueryLoader(QueryTranslatorImpl queryTranslator, ISessionFactoryImplementor factory, SelectClause selectClause) : base(factory)
		{
			_queryTranslator = queryTranslator;
			_selectClause = selectClause;

			Initialize(selectClause);
			PostInstantiate();
		}

		/// <summary>
		/// Returns the locations of all occurrences of the named parameter.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public override int[] GetNamedParameterLocs(string name)
		{
			return _queryTranslator.GetParameterTranslations().GetNamedParameterSqlLocations(name);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="lockModes">a collection of lock modes specified dynamically via the Query interface</param>
		/// <returns></returns>
		protected override LockMode[] GetLockModes(IDictionary<string, LockMode> lockModes)
		{
			if (lockModes == null || lockModes.Count == 0)
			{
				return _defaultLockModes;
			}
			else
			{
				// unfortunately this stuff can't be cached because
				// it is per-invocation, not constant for the
				// QueryTranslator instance

				LockMode[] lockModeArray = new LockMode[_entityAliases.Length];
				for (int i = 0; i < _entityAliases.Length; i++)
				{
					LockMode lockMode = lockModes[_entityAliases[i]];
					if (lockMode == null)
					{
						//NONE, because its the requested lock mode, not the actual! 
						lockMode = LockMode.None;
					}
					lockModeArray[i] = lockMode;
				}
				return lockModeArray;
			}
		}

		protected override SqlString SqlString
		{
			get { return _queryTranslator.SqlString; }
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
					FromElement collectionFromElement = collectionFromElements[i];
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

		public IList List(ISessionImplementor session, QueryParameters queryParameters) 
		{
			CheckQuery( queryParameters );
			return List( session, queryParameters, _queryTranslator.QuerySpaces, _queryReturnTypes );
		}

		protected override object GetResultColumnOrRow(object[] row, IResultTransformer resultTransformer, IDataReader rs, ISessionImplementor session)
		{
			row = ToResultRow(row);
			bool hasTransform = HasSelectNew || resultTransformer != null;

			if (_hasScalars)
			{
				string[][] scalarColumns = _scalarColumnNames;
				int queryCols = _queryReturnTypes.Length;

				if (!hasTransform && queryCols == 1)
				{
					return _queryReturnTypes[0].NullSafeGet(rs, scalarColumns[0], session, null);
				}
				else
				{
					row = new object[queryCols];
					for (int i = 0; i < queryCols; i++)
					{
						row[i] = _queryReturnTypes[i].NullSafeGet(rs, scalarColumns[i], session, null);
					}
					return row;
				}
			}
			else if (!hasTransform)
			{
				return row.Length == 1 ? row[0] : row;
			}
			else
			{
				return row;
			}
		}

		private object[] ToResultRow(object[] row)
		{
			if (_selectLength == row.Length)
			{
				return row;
			}

			object[] result = new object[_selectLength];
			int j = 0;
			for (int i = 0; i < row.Length; i++)
			{
				if (_includeInSelect[i])
				{
					result[j++] = row[i];
				}
			}
			return result;
		}

		private void CheckQuery(QueryParameters queryParameters)
		{
			if (HasSelectNew && queryParameters.ResultTransformer != null)
			{
				throw new QueryException("ResultTransformer is not allowed for 'select new' queries.");
			}
		}

		private bool HasSelectNew
		{
			get { return _selectNewTransformer != null; }
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
