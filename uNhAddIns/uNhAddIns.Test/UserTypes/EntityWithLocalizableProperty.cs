using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace uNhAddIns.Test.UserTypes
{
	public class EntityWithLocalizableProperty
	{
		public virtual string Description
		{
			get
			{
				return LocalizableProperty.Count > 0
				       	? LocalizableProperty.First(e => e.Key.Equals(Thread.CurrentThread.CurrentCulture)).Value
				       	: null;
			}
			set
			{
				if (value == null)
				{
					LocalizableProperty.Remove(Thread.CurrentThread.CurrentCulture);
				}
				else
				{
					LocalizableProperty[Thread.CurrentThread.CurrentCulture] = value;
				}
			}
		}

		public virtual Dictionary<CultureInfo, string> LocalizableProperty { get; set; }
	}
}