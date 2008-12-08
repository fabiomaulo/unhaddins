using System;
using System.Collections;
using System.Collections.Generic;
using Iesi.Collections.Generic;
using log4net;
using NHibernate.Engine;
using NHibernate.Type;

namespace NHibernate.Hql.Ast
{
	public class QueryTranslator : IQueryTranslator
	{
		private readonly static ILog log = LogManager.GetLogger(typeof(QueryTranslator));
		private readonly ISessionFactoryImplementor factory;
		private readonly IDictionary<string, IFilter> filters;
		private readonly IHqlParser<string> parser;
		private readonly string query;
		private readonly string queryIdentifier;

		/// <summary> 
		/// Creates a new AST-based query translator. 
		/// </summary>
		/// <param name="queryIdentifier">The query-identifier (used in stats collection) </param>
		/// <param name="query">The hql query to translate </param>
		/// <param name="filters">Currently enabled filters </param>
		/// <param name="parser">The implementation of a string hql parser</param>
		/// <param name="factory">The session factory constructing this translator instance. </param>
		public QueryTranslator(string queryIdentifier, string query, IDictionary<string, IFilter> filters,
													 IHqlParser<string> parser, ISessionFactoryImplementor factory)
		{
			this.queryIdentifier = queryIdentifier;
			this.query = query;
			this.filters = filters;
			this.parser = parser;
			this.factory = factory;
		}

		#region Implementation of IQueryTranslator

		public void Compile(IDictionary<string, string> replacements, bool shallow)
		{
			ISyntaxNode root = parser.Parse(query);
		}

		public IList List(ISessionImplementor session, QueryParameters queryParameters)
		{
			throw new NotImplementedException();
		}

		public IEnumerable GetEnumerable(QueryParameters queryParameters, ISessionImplementor session)
		{
			throw new NotImplementedException();
		}

		public int ExecuteUpdate(QueryParameters queryParameters, ISessionImplementor session)
		{
			throw new NotImplementedException();
		}

		public string[][] GetColumnNames()
		{
			throw new NotImplementedException();
		}

		public IParameterTranslations GetParameterTranslations()
		{
			throw new NotImplementedException();
		}

		public ISet<string> QuerySpaces
		{
			get { throw new NotImplementedException(); }
		}

		public string SQLString
		{
			get { throw new NotImplementedException(); }
		}

		public IList<string> CollectSqlStrings
		{
			get { throw new NotImplementedException(); }
		}

		public string QueryString
		{
			get { throw new NotImplementedException(); }
		}

		public IDictionary<string, IFilter> EnabledFilters
		{
			get { throw new NotImplementedException(); }
		}

		public IType[] ReturnTypes
		{
			get { throw new NotImplementedException(); }
		}

		public string[] ReturnAliases
		{
			get { throw new NotImplementedException(); }
		}

		public bool ContainsCollectionFetches
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsManipulationStatement
		{
			get { throw new NotImplementedException(); }
		}

		#endregion
	}
}