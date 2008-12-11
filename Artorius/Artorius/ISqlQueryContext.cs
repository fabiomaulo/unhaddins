using System.Collections.Generic;
using NHibernate.Engine;

namespace NHibernate.Hql.Ast
{
	public interface ISqlQueryContext
	{
		ISessionFactoryImplementor Factory { get; }
		IDictionary<string, IFilter> EnabledFilters { get; }
		IDictionary<string, string> Replacements { get; }
	}
}