using System;
using System.Collections.Generic;
using Castle.Windsor;
using NHibernate;
using uNhAddIns.Adapters;

namespace uNhAddIns.CastleAdapters.Tests.AutomaticConversationManagement
{
	[Serializable]
	public class Other
	{
		public virtual int Id { get; set; }

		public virtual string Name { get; set; }
	}

	[Serializable]
	public class Silly
	{
		public virtual int Id { get; set; }

		public virtual string Name { get; set; }

		public virtual Other Other { get; set; }
	}

	public interface IDaoFactory
	{
		TDao GetDao<TDao>();
	}

	public class DaoFactory : IDaoFactory
	{
		private readonly IWindsorContainer container;

		public DaoFactory(IContainerAccessor accessor)
		{
			container = accessor.Container;
		}

		public TDao GetDao<TDao>()
		{
			return container.Resolve<TDao>();
		}
	}

	public interface ISillyDao
	{
		Silly Get(int id);
		IList<Silly> GetAll();
		Silly MakePersistent(Silly entity);
		void MakeTransient(Silly entity);
	}

	public class SillyDao : ISillyDao
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

	public interface ISillyCrudModel
	{
		IList<Silly> GetEntirelyList();
		Silly GetIfAvailable(int id);
		Silly Save(Silly entity);
		void Delete(Silly entity);
		void AcceptAll();
		void Abort();
	}

	[PersistenceConversational]
	public class SillyCrudModel : ISillyCrudModel
	{
		private readonly IDaoFactory factory;

		public SillyCrudModel(IDaoFactory factory)
		{
			if (factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			this.factory = factory;
		}

		protected ISillyDao EntityDao
		{
			get { return factory.GetDao<ISillyDao>(); }
		}

		#region Implementation of ISillyCrudModel
		[PersistenceConversation]
		public virtual IList<Silly> GetEntirelyList()
		{
			return EntityDao.GetAll();
		}

		[PersistenceConversation]
		public virtual Silly GetIfAvailable(int id)
		{
			return EntityDao.Get(id);
		}

		[PersistenceConversation]
		public virtual Silly Save(Silly entity)
		{
			return EntityDao.MakePersistent(entity);
		}

		[PersistenceConversation]
		public virtual void Delete(Silly entity)
		{
			EntityDao.MakeTransient(entity);
			entity.Id = 0;
		}

		[PersistenceConversation(EndConversation = true)]
		public virtual void AcceptAll()
		{
			// metodo para fin de UseCase
		}

		[PersistenceConversation(AbortConversation = true)]
		public virtual void Abort()
		{
			// metodo para abort de use case
		}

		#endregion
	}
}