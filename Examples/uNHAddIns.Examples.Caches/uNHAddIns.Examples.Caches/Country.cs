namespace uNHAddIns.Examples.Caches
{
	public class Country
	{
		public Country()
		{
		}

		public Country(string name)
		{
			this.name = name;
		}

		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	}
}