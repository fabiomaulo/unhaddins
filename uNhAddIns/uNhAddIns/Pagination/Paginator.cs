using System;
using System.Collections.Generic;

namespace uNhAddIns.Pagination
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Paginator<T> : BasePaginator, IPageProvider<T>
	{
		private int pageSize;
		private long? rowsCount;
		private bool autoCalcPages = false;
		private IRowsCounter counter;
		private readonly IPaginable<T> source;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pageSize"></param>
		/// <param name="paginable"></param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public Paginator(int pageSize, IPaginable<T> paginable)
		{
			if (paginable == null)
				throw new ArgumentNullException("paginable");
			if (pageSize <= 0)
				throw new ArgumentOutOfRangeException("pageSize",
				                                      string.Format("Page size expected greater than zero ; was {0}.", pageSize));
			this.pageSize = pageSize;
			source = paginable;
			// Check if the paginable implements IRowsCounter too
			Counter = paginable as IRowsCounter;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pageSize"></param>
		/// <param name="paginable"></param>
		/// <param name="autoCalcPages"></param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public Paginator(int pageSize, IPaginable<T> paginable, bool autoCalcPages)
			: this(pageSize, paginable)
		{
			this.autoCalcPages = autoCalcPages;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pageSize"></param>
		/// <param name="paginable"></param>
		/// <param name="counter"></param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public Paginator(int pageSize, IPaginable<T> paginable, IRowsCounter counter)
			: this(pageSize, paginable)
		{
			Counter = counter;
		}

		/// <summary>
		/// 
		/// </summary>
		public bool AutoCalcPages
		{
			get { return autoCalcPages; }
		}

		/// <summary>
		/// 
		/// </summary>
		public IRowsCounter Counter
		{
			get { return counter; }
			protected set
			{
				counter = value;
				autoCalcPages = counter != null;
			}
		}

		#region IPageProvider<T> Members

		/// <summary>
		/// Number of visible objects of each page.
		/// </summary>
		public int PageSize
		{
			get { return pageSize; }
			set
			{
				if (!pageSize.Equals(value))
				{
					pageSize = value;
					ResetLastPageNumber();
				}
			}
		}

		/// <summary>
		/// The total rows count.
		/// </summary>
		/// <remarks>Return null if rows count is not available.</remarks>
		public long? RowsCount
		{
			get
			{
				if (!LastPageNumber.HasValue && AutoCalcPages) CalcLastPage();
				return rowsCount;
			}
		}

		/// <summary>
		/// Get the list of objects for a given page number.
		/// </summary>
		/// <param name="pageNumber">The page number.</param>
		/// <returns>The list of objects.</returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public IList<T> GetPage(int pageNumber)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Get the list of objects of the first page.
		/// </summary>
		/// <returns>The list of objects.</returns>
		public IList<T> GetFirstPage()
		{
			return GetPage(FirstPageNumber);
		}

		/// <summary>
		/// Get the list of objects of the last page.
		/// </summary>
		/// <returns>The list of objects.</returns>
		/// <exception cref="NotSupportedException">When <see cref="AutoCalcPages"/> is false</exception>
		public IList<T> GetLastPage()
		{
			if (!LastPageNumber.HasValue)
				throw new NotSupportedException("GetLastPage() is not supported when AutoCalcPages is false.");
			return GetPage(LastPageNumber.Value);
		}

		/// <summary>
		/// Get the list of objects of the next page.
		/// </summary>
		/// <returns>The list of objects.</returns>
		public IList<T> GetNextPage()
		{
			return GetPage(NextPageNumber);
		}

		/// <summary>
		/// Get the list of objects of the previous page.
		/// </summary>
		/// <returns>The list of objects.</returns>
		public IList<T> GetPreviousPage()
		{
			return GetPage(PreviousPageNumber);
		}

		#endregion

		/// <summary>
		/// The number of the last page if available; otherwise null.
		/// </summary>
		public override int? LastPageNumber
		{
			get
			{
				if (!base.LastPageNumber.HasValue && AutoCalcPages) CalcLastPage();
				return base.LastPageNumber;
			}
		}

		private void CalcLastPage()
		{
			if (counter != null)
				rowsCount = counter.GetRowsCount(source.GetSession());
			else
				rowsCount = source.ListAll().Count;
			ResetLastPageNumber();
		}

		private void ResetLastPageNumber() 
		{
			LastPageNumber = Convert.ToInt32(rowsCount / PageSize) + ((rowsCount % PageSize) == 0 ? 0 : 1);
		}
	}
}