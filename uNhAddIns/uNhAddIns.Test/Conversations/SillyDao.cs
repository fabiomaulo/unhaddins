using System.Collections.Generic;
using NHibernate;

namespace uNhAddIns.Test.Conversations
{
	public class SillyDao
	{
		private readonly ISessionFactory factory;

		public SillyDao(ISessionFactory factory)
		{
			this.factory = factory;
		}

		public Silly Get(int id)
		{
			return factory.GetCurrentSession().Get<Silly>(id);
		}

		public IList<Silly> GetAll()
		{
			return factory.GetCurrentSession().CreateQuery("from Silly").List<Silly>();
		}

		public Silly MakePersistent(Silly entity)
		{
			factory.GetCurrentSession().SaveOrUpdate(entity);
			return entity;
		}

		public void MakeTransient(Silly entity)
		{
			factory.GetCurrentSession().Delete(entity);
		}
	}
}