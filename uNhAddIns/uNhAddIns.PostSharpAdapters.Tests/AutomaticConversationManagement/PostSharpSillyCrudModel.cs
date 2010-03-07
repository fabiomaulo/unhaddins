using System;
using System.Collections.Generic;
using uNhAddIns.Adapters;
using uNhAddIns.Adapters.CommonTests;
using uNhAddIns.Adapters.CommonTests.ConversationManagement;
using uNhAddIns.Adapters.CommonTests.Integration;

namespace uNhAddIns.PostSharpAdapters.Tests.AutomaticConversationManagement
{
	[PsPersistenceConversational(MethodsIncludeMode = MethodsIncludeMode.Explicit)]
	public class PostSharpSillyCrudModel : ISillyCrudModel
	{
		private readonly IDaoFactory factory;

		public PostSharpSillyCrudModel(IDaoFactory factory)
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

	[PsPersistenceConversational(ConversationCreationInterceptor = typeof(ConversationCreationInterceptor))]
	public class PostSharpInheritedSillyCrudModelWithConcreteConversationCreationInterceptor : PostSharpSillyCrudModel
	{
		public PostSharpInheritedSillyCrudModelWithConcreteConversationCreationInterceptor(IDaoFactory factory) 
			: base(factory) { }
		
		public override Silly GetIfAvailable(Guid id)
		{
			return base.GetIfAvailable(id);
		}
	}

	[PsPersistenceConversational(DefaultEndMode = EndMode.End)]
	public class PostSharpSillyCrudModelDefaultEnd : PostSharpSillyCrudModel
	{
		public PostSharpSillyCrudModelDefaultEnd(IDaoFactory factory) : base(factory) { }
		
		public override Silly GetIfAvailable(Guid id)
		{
			return base.GetIfAvailable(id);
		}
	}


	[PsPersistenceConversational(MethodsIncludeMode = MethodsIncludeMode.Implicit)]
	public class PostSharpSillyCrudModelWithImplicit : ISillyCrudModelExtended
	{
		private readonly IDaoFactory factory;

		public PostSharpSillyCrudModelWithImplicit(IDaoFactory factory)
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

		public virtual IList<Silly> GetEntirelyList()
		{
			return GetEntirelyListPrivate();
		}

		public virtual Silly GetIfAvailable(Guid id)
		{
			return EntityDao.Get(id);
		}

		public virtual Silly Save(Silly entity)
		{
			return EntityDao.MakePersistent(entity);
		}

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

		public string PropertyOutConversation
		{
			[PersistenceConversation(Exclude = true)]
			get { return null; }
		}

		public string PropertyInConversation
		{
			get { return null; }
		}

		[PersistenceConversation(Exclude = true)]
		public virtual void DoSomethingNoPersistent() { }

		[PersistenceConversation]
		private IList<Silly> GetEntirelyListPrivate()
		{
			return EntityDao.GetAll();
		}
	}


	[PsPersistenceConversational]
	public class PostSharpInheritedSillyCrudModelWithConvetionConversationCreationInterceptor : PostSharpSillyCrudModel
	{
		public PostSharpInheritedSillyCrudModelWithConvetionConversationCreationInterceptor(IDaoFactory factory) 
			: base(factory) { }
		
		public override Silly GetIfAvailable(Guid id)
		{
			return base.GetIfAvailable(id);
		}
	}
}