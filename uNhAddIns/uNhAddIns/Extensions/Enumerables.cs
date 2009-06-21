using System.Collections.Generic;
using System.Text;

namespace uNhAddIns.Extensions
{
	public static class Enumerables
	{
		public static string ConcatWithSeparator(this IEnumerable<string> source, char separator)
		{
			var result = new StringBuilder(128);
			bool separatorFirst = false;
			foreach (var part in source)
			{
				if (separatorFirst)
				{
					result.Append(separator).Append(part);
				}
				else
				{
					result.Append(part);
					separatorFirst = true;
				}
			}
			return result.ToString();
		}
	}
}