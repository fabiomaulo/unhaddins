using System;

namespace uNhAddIns.Pagination
{
	public class BasePaginator:IPaginator 
	{
		private int? currentPageNumber;
		private int? lastPageNumber;

		public BasePaginator() {}

		public BasePaginator(int lastPageNumber)
		{
			this.lastPageNumber = lastPageNumber;
		}

		#region IPaginator Members

		/// <summary>
		/// The number of the current page.
		/// </summary>
		public int? CurrentPageNumber
		{
			get { return currentPageNumber; }
			protected set { currentPageNumber = value; }
		}

		/// <summary>
		/// The number of the last page.
		/// </summary>
		public virtual int? LastPageNumber
		{
			get { return lastPageNumber; }
			protected set { lastPageNumber = value; }
		}

		/// <summary>
		/// The number of the next page.
		/// </summary>
		public int NextPageNumber
		{
			get
			{
				return
					(!LastPageNumber.HasValue)
						? currentPageNumber.GetValueOrDefault() + 1
						: (currentPageNumber.GetValueOrDefault() + 1) > LastPageNumber.Value
						  	? LastPageNumber.Value
						  	: currentPageNumber.GetValueOrDefault() + 1;
			}
		}

		/// <summary>
		/// The number of the previous page.
		/// </summary>
		public int PreviousPageNumber
		{
			get 
			{
				return
					((currentPageNumber.GetValueOrDefault() - 1) < FirstPageNumber)
						? FirstPageNumber
						: currentPageNumber.GetValueOrDefault() - 1;
			}
		}

		/// <summary>
		/// The number of the first page.
		/// </summary>
		public int FirstPageNumber
		{
			get { return 1; }
		}

		/// <summary>
		/// True if has a previous page; false otherwise.
		/// </summary>
		public bool HasPrevious
		{
			get { return currentPageNumber > FirstPageNumber; }
		}

		/// <summary>
		/// True if has a next page; false otherwise.
		/// </summary>
		public bool HasNext
		{
			get { return !LastPageNumber.HasValue || currentPageNumber < LastPageNumber; }
		}

		#endregion

		/// <summary>
		/// Move the curret page to a given page number.
		/// </summary>
		/// <param name="pageNumber">The page number.</param>
		/// <exception cref="ArgumentOutOfRangeException">When the <paramref name="pageNumber"/> is great
		/// then <see cref="LastPageNumber"/>.
		/// </exception>
		protected void GotoPageNumber(int pageNumber)
		{
			if (LastPageNumber.HasValue && pageNumber > LastPageNumber)
				throw new ArgumentOutOfRangeException("pageNumber");
			currentPageNumber = pageNumber;
		}
	}
}