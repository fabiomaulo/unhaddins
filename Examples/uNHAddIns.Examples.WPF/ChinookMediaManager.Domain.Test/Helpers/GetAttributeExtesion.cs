using System;
using System.Linq;
using System.Reflection;

namespace ChinookMediaManager.Domain.Test.Helpers
{
	public static class GetAttributeExtesion
	{
		public static T GetAttribute<T>(this ICustomAttributeProvider provider) where T : Attribute
		{
			return (T) provider.GetCustomAttributes(typeof (T), true).FirstOrDefault();
		}
	}
}