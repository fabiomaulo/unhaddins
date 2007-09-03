using NHibernate;
using uNhAddIns.NH;

namespace uNhAddIns.Pagination
{
	public abstract class PaginableRowsCounterQuery<T> : AbstractPaginableQuery<T>, IRowsCounter 
	{
		protected abstract IDetachedQuery GetRowCountQuery();

		#region IRowsCounter Members

		private QueryRowsCounter dqrc;

		/// <summary>
		/// Get the row count.
		/// </summary>
		/// <param name="session">The <see cref="ISession"/>.</param>
		/// <returns>The row count.</returns>
		public long GetRowsCount(ISession session)
		{
			if (dqrc == null)
				dqrc = new QueryRowsCounter(GetRowCountQuery());
			return dqrc.GetRowsCount(session);
		}

		#endregion
	}
}