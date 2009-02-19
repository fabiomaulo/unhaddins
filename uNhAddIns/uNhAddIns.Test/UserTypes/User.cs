using System;

namespace uNhAddIns.Test.UserTypes
{
	[Serializable]
	public class User
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Password { get; set; }
		public virtual string OtherEncripted { get; set; }
	}
}