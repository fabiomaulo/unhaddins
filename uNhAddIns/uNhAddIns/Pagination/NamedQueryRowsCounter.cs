using System;
using uNhAddIns.Impl;

namespace uNhAddIns.Pagination
{
	/// <summary>
	/// 
	/// </summary>
	public class NamedQueryRowsCounter : AbstractRowsCounter
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="queryRowsCount"></param>
		public NamedQueryRowsCounter(string queryRowsCount)
		{
			if (string.IsNullOrEmpty(queryRowsCount))
				throw new ArgumentNullException("queryRowsCount");
			dq = new DetachedNamedQuery(queryRowsCount);
		}
	}
}