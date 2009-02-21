using System;

namespace ANTLR_HQL.Tests
{
	public class Human : Animal
	{
		private Name _name;
		public virtual Name Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _nickName;
		public virtual string NickName
		{
			get { return _nickName; }
			set { _nickName = value; }
		}

		private DateTime _birthdate;
		public virtual DateTime Birthdate
		{
			get { return _birthdate; }
			set { _birthdate = value; }
		}

	}
}
