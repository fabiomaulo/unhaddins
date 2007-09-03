using System;
using NHibernate;
using uNhAddIns.NH.Expression;
using uNhAddIns.Pagination;

namespace uNhAddIns.GenericImpl
{
	/// <summary>
	/// Generic implementation of <see cref="IPaginable{T}"/> based on <see cref="DetachedCriteria"/>.
	/// </summary>
	/// <typeparam name="T">The type of DAO.</typeparam>
	/// <seealso cref="uNhAddIns.NH.Expression.DetachedCriteria"/>
	public class PaginableCriteria<T> : AbstractPaginableCriteria<T>
	{
		private readonly ISession session;
		private readonly DetachedCriteria detachedCriteria;

		/// <summary>
		/// Create a new instance of <see cref="PaginableCriteria{T}"/>.
		/// </summary>
		/// <param name="session">The session (may be the same session of the DAO).</param>
		/// <param name="detachedCriteria">The detached criteria.</param>
		public PaginableCriteria(ISession session, DetachedCriteria detachedCriteria)
		{
			if (detachedCriteria == null)
			{
				throw new ArgumentNullException("detachedCriteria");
			}
			this.session = session;
			this.detachedCriteria = detachedCriteria;
		}
		
		protected override DetachedCriteria Criteria
		{
			get { return detachedCriteria; }
		}

		public override ISession GetSession()
		{
			return session;
		}
	}
}