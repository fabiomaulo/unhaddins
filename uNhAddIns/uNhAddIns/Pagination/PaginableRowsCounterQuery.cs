using NHibernate;
using uNhAddIns.Impl;

namespace uNhAddIns.Pagination
{
	public abstract class PaginableRowsCounter<T> : AbstractPaginableQuery<T>, IRowsCounter 
	{
		protected abstract DetachedQuery GetQuery();

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
				dqrc = QueryRowsCounter.Transforming(GetQuery());
			return dqrc.GetRowsCount(session);
		}

		#endregion
	}
}