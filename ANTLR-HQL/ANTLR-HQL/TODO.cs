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
}
