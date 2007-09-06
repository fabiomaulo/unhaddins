using System;
using System.Collections;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Expression;
using NHibernate.SqlCommand;

namespace uNhAddIns.Criterions
{
	/// <summary>
	/// An <see cref="ICriterion"/> that represents an "equal" or "null" constraint dependig on
	/// the value of the property.
	/// </summary>
	/// <seealso cref="NHibernate.Expression.EqExpression"/>
	/// <seealso cref="NHibernate.Expression.NullExpression"/>
	public class EqOrNullExpression : AbstractCriterion
	{
		private readonly ICriterion realCriterion;
		
		/// <summary>
		/// Initialize a new instance of the <see cref="EqOrNullExpression" /> class for a named
		/// Property and its value.
		/// </summary>
		/// <param name="propertyName">The name of the Property in the class.</param>
		/// <param name="value">The value for the Property.</param>
		public EqOrNullExpression(string propertyName, object value)
			: this(propertyName, value, false) {}

		public EqOrNullExpression(string propertyName, object value, bool ignoreCase)
		{
			if (string.IsNullOrEmpty(propertyName))
				throw new ArgumentNullException("propertyName");
			if(value==null)
				realCriterion = new NullExpression(propertyName);
			else
				realCriterion= new EqExpression(propertyName, value, ignoreCase);
		}

		public override string ToString()
		{
			return realCriterion.ToString();
		}

		public override SqlString ToSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery, IDictionary enabledFilters)
		{
			return realCriterion.ToSqlString(criteria, criteriaQuery, enabledFilters);
		}

		public override TypedValue[] GetTypedValues(ICriteria criteria, ICriteriaQuery criteriaQuery)
		{
			return realCriterion.GetTypedValues(criteria, criteriaQuery);
		}
	}
}
