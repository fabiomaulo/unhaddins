using System;
using uNhAddIns.NH;
using uNhAddIns.Pagination;

namespace uNhAddIns.DynQuery
{
	public abstract class PaginableDynQuery<T> : AbstractPaginableRowsCounterQuery<T>
	{
		private readonly DetachedDynQuery query;

		public PaginableDynQuery(DetachedDynQuery query)
		{
			if (query == null)
				throw new ArgumentNullException("query");

			this.query = query;
		}

		protected override IDetachedQuery GetRowCountQuery()
		{
			return query.TransformToRowCount();
		}

		protected override IDetachedQuery DetachedQuery
		{
			get { return query; }
		}
	}
}
