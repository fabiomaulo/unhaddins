using System.Collections.Generic;

namespace uNhAddIns.Cache
{
	public interface ITolerantQueryCacheConfiguration
	{
		void TolerantWith(string querySpace);
		void TolerantWith(IEnumerable<string> querySpace);
	}
}