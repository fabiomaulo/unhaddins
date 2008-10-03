using System;

namespace uNhAddIns.Test.Conversations
{
	[Serializable]
	public class Other
	{
		public virtual long Id { get; set; }

		public virtual string Name { get; set; }
	}

	[Serializable]
	public class Silly
	{
		public virtual long Id { get; set; }

		public virtual string Name { get; set; }

		public virtual Other Other { get; set; }
	}
}