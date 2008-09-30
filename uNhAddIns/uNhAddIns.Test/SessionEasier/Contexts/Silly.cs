using System;

namespace uNhAddIns.Test.SessionEasier.Contexts
{
	[Serializable]
	public class Silly
	{
		public virtual long Id { get; set; }

		public virtual string Name { get; set; }

		public virtual Other Other { get; set; }
	}
}