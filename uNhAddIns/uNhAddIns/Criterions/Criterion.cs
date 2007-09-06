using NHibernate.Expression;

namespace uNhAddIns.Criterions
{
	/// <summary>
	/// Build in criterions.
	/// </summary>
	public static class Criterion
	{
		/// <summary>
		/// Apply an "equal" or "is null" constraint to the named property
		/// </summary>
		/// <param name="propertyName">The name of the Property in the class.</param>
		/// <param name="value">The value for the Property.</param>
		/// <returns>An <see cref="EqOrNullExpression" />.</returns>
		/// <remarks>
		/// If the <paramref name="value"/> is null the criterion apply the "is null" constraint;
		/// otherwise apply the "equal" constraint
		/// </remarks>
		/// <seealso cref="NHibernate.Expression.EqExpression"/>
		/// <seealso cref="NHibernate.Expression.NullExpression"/>
		public static ICriterion EqOrNull(string propertyName, object value)
		{
			return new EqOrNullExpression(propertyName, value);
		}
	}
}
