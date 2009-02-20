using System;
using NHibernate.Engine;
using NHibernate.Type;

namespace NHibernate.Hql.Ast.ANTLR.Parameters
{
	public class DynamicFilterParameterSpecification : IParameterSpecification
	{
		private readonly string _filterName;
		private readonly string _parameterName;
		private readonly IType _definedParameterType;

		/// <summary>
		/// Constructs a parameter specification for a particular filter parameter.
		/// </summary>
		/// <param name="filterName">The name of the filter</param>
		/// <param name="parameterName">The name of the parameter</param>
		/// <param name="definedParameterType">The paremeter type specified on the filter metadata</param>
		public DynamicFilterParameterSpecification(
				string filterName,
				string parameterName,
				IType definedParameterType)
		{
			_filterName = filterName;
			_parameterName = parameterName;
			_definedParameterType = definedParameterType;
		}

		public int Bind(object statement, QueryParameters qp, ISessionImplementor session, int position)
		{
			throw new NotImplementedException();
		}

		public IType ExpectedType
		{
			get { return _definedParameterType; }
			set { throw new System.NotImplementedException(); }
		}

		public string RenderDisplayInfo()
		{
			return "dynamic-filter={filterName=" + _filterName + ",paramName=" + _parameterName + "}";
		}
	}
}
