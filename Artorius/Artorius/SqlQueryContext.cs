using System.Collections.Generic;
using NHibernate.Engine;

namespace NHibernate.Hql.Ast
{
	public class SqlQueryContext : ISqlQueryContext
	{
		public SqlQueryContext(ISessionFactoryImplementor factory, IDictionary<string, IFilter> enabledFilters, IDictionary<string, string> replacements)
		{
			Factory = factory;
			EnabledFilters = enabledFilters;
			Replacements = replacements;
		}

		#region Implementation of ISqlQueryContext

		public ISessionFactoryImplementor Factory { get; private set; }
		public IDictionary<string, IFilter> EnabledFilters { get; private set; }
		public IDictionary<string, string> Replacements { get; private set; }

		#endregion
	}
}