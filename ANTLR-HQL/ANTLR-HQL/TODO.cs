using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.SqlCommand;

namespace NHibernate.Hql.Ast.ANTLR
{
	public static class TODO
	{
		public static bool HasThetaJoins(this JoinFragment frag)
		{
			// TODO - look at this
			return false;
		}
	}

	public class LoadQueryInfluencers
	{
		public static string[] ParseFilterParameterName(string filterParameterName)
		{
			int dot = filterParameterName.IndexOf(".");
			if (dot <= 0)
			{
				throw new ArgumentException("Invalid filter-parameter name format", "filterParameterName");
			}
			string filterName = filterParameterName.Substring(0, dot);
			string parameterName = filterParameterName.Substring(dot + 1);
			return new[] { filterName, parameterName };
		}
	}

	public class Tuple<T1, T2>
	{
		private readonly T1 _t1;
		private readonly T2 _t2;

		public Tuple(T1 t1, T2 t2)
		{
			_t1 = t1;
			_t2 = t2;
		}

		public T1 First
		{
			get { return _t1; }
		}

		public T2 Second
		{
			get { return _t2; }
		}
	}
}
