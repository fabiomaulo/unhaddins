using System.Collections.Generic;
using uNhAddIns.Example.MultiSessionConversationUsage.Entities;
using NHibernate;

namespace uNhAddIns.Example.MultiSessionConversationUsage.DataAccessObjects
{
	public class PersonDao : BaseCrudDao<Person>, IPersonDao
	{
		public PersonDao(ISessionFactory factory) : base(factory) {}

		#region Implementation of IAnimalReadOnlyDao<TAnimal>

		public IList<Person> GetAll()
		{
			return factory.GetCurrentSession().CreateCriteria<Person>().List<Person>();
		}

		#endregion
	}
}