using System.Collections.Generic;
using NHibernate;
using uNhAddIns.Example.ConversationUsage.Entities;
namespace uNhAddIns.Example.ConversationUsage.DataAccessObjects
{
	public class AnimalDao<TAnimal> : BaseCrudDao<TAnimal>, IAnimalReadOnlyDao<TAnimal> where TAnimal: Animal
	{
		protected AnimalDao(ISessionFactory factory) : base(factory) {}

		#region Implementation of IAnimalReadOnlyDao<TAnimal>

		public IList<TAnimal> GetAll()
		{
			return
				factory.GetCurrentSession().CreateCriteria(typeof(TAnimal))
				.List<TAnimal>();
		}

		#endregion
	}
}