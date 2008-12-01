using System;

namespace uNhAddIns.Test.UserTypes
{
	[Serializable]
	public class User
	{
		private string name;
		private string password;
		private int id;

		public User()
		{
			
		}

		public User(int id, string name, string password)
		{
			this.id = id;
			this.password = password;
			this.name = name;
		}

		public virtual int Id
		{
			get { return id; }
			set { id = value; }
		}
		
		public virtual string Name
		{
			get { return name; }
			set { name = value; }
		}

		public virtual string Password
		{
			get { return password; }
			set { password = value; }
		}
	}
}
