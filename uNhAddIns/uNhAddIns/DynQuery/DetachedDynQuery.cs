using System;
using NHibernate;
using uNhAddIns.NH;
using uNhAddIns.NH.Impl;

namespace uNhAddIns.DynQuery
{
	[Serializable]
	public class DetachedDynQuery : AbstractDetachedQuery
	{
		private readonly From from;
		private readonly Select select;

		public DetachedDynQuery(Select select)
		{
			if (select == null)
				throw new ArgumentNullException("select");

			this.select = select;
			from = select.From();
		}

		public DetachedDynQuery(From from)
		{
			if (from == null)
				throw new ArgumentNullException("from");

			this.from = from;
		}

		/// <summary>
		/// Get an executable instance of <see cref="IQuery"/>, to actually run the query.
		/// </summary>
		public override IQuery GetExecutableQuery(ISession session)
		{
			IQuery result = session.CreateQuery((select != null) ? select.Clause : from.Clause);
			SetQueryProperties(result);
			return result;
		}

		public IDetachedQuery TransformToRowCount()
		{
			Select s = new Select("select count(*)");
			s.SetFrom(from.FromWhereClause());
			DetachedQuery result = new DetachedQuery(s.Clause);
			result.CopyParametersFrom(this);
			return result;
		}
	}
}
