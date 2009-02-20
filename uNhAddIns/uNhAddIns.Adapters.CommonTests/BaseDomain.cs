using System;
using System.Collections.Generic;

namespace uNhAddIns.Adapters.CommonTests
{
    [Serializable]
    public class Other
    {
        private readonly Guid _id = Guid.NewGuid();
        public virtual Guid Id
        {
            get { return _id; }
        }

        private readonly int _concurrencyId = -1;
        public virtual int ConcurrencyId
        {
            get { return _concurrencyId; }
        }

        public virtual string Name { get; set; }
    }


    [Serializable]
    public class Silly
    {
        public Silly() {}

        public Silly(Guid id)
        {
            _id = id;
        }

        private readonly Guid _id = Guid.NewGuid();
        public virtual Guid Id
        {
            get { return _id; }
        }

        private readonly int _concurrencyId = -1;
        public virtual int ConcurrencyId
        {
            get { return _concurrencyId; }
        }

        public virtual string Name { get; set; }

        public virtual Other Other { get; set; }
    }


	public interface IDaoFactory
	{
		TDao GetDao<TDao>();
	}

	public interface ISillyDao
	{
		Silly Get(Guid id);
		IList<Silly> GetAll();
		Silly MakePersistent(Silly entity);
		void MakeTransient(Silly entity);
	}

	public interface ISillyCrudModel
	{
		IList<Silly> GetEntirelyList();
		Silly GetIfAvailable(Guid id);
		Silly Save(Silly entity);
		void Delete(Silly entity);
		void ImmediateDelete(Silly entity);
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
		public virtual Silly GetIfAvailable(Guid id)
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
		}

		[PersistenceConversation(ConversationEndMode = EndMode.CommitAndContinue)]
		public virtual void ImmediateDelete(Silly entity)
		{
			EntityDao.MakeTransient(entity);
		}

		[PersistenceConversation(ConversationEndMode = EndMode.End)]
		public virtual void AcceptAll()
		{
			// method for use-case End
		}

		[PersistenceConversation(ConversationEndMode = EndMode.Abort)]
		public virtual void Abort()
		{
			// method for use-case Abort
		}

		#endregion
	}
}