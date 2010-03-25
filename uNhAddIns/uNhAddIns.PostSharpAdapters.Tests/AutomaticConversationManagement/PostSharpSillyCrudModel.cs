using System;
using System.Collections.Generic;
using PostSharp.Extensibility;
using uNhAddIns.Adapters;
using uNhAddIns.Adapters.CommonTests;
using uNhAddIns.Adapters.CommonTests.ConversationManagement;
using uNhAddIns.Adapters.CommonTests.Integration;

namespace uNhAddIns.PostSharpAdapters.Tests.AutomaticConversationManagement
{
	[ImplicitConversation(AttributeInheritance = MulticastInheritance.Multicast)]
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

		
		public virtual IList<Silly> GetEntirelyList()
		{
			return EntityDao.GetAll();
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

		[ImplicitConversation(EndMode = EndMode.CommitAndContinue)]
		public virtual void ImmediateDelete(Silly entity)
		{
			EntityDao.MakeTransient(entity);
		}

		[ImplicitConversation(EndMode = EndMode.End)]
		public virtual void AcceptAll()
		{
			// method for use-case End
		}

		[ImplicitConversation(EndMode = EndMode.Abort)]
		public virtual void Abort()
		{
			// method for use-case Abort
		}

		#endregion
	}

	[ImplicitConversation(ConversationCreationInterceptor = typeof(ConversationCreationInterceptor))]
	public class PostSharpInheritedSillyCrudModelWithConcreteConversationCreationInterceptor : PostSharpSillyCrudModel
	{
		public PostSharpInheritedSillyCrudModelWithConcreteConversationCreationInterceptor(IDaoFactory factory) 
			: base(factory) { }
		
		public override Silly GetIfAvailable(Guid id)
		{
			return base.GetIfAvailable(id);
		}
	}

	
	public class PostSharpSillyCrudModelDefaultEnd : PostSharpSillyCrudModel
	{
		public PostSharpSillyCrudModelDefaultEnd(IDaoFactory factory) : base(factory) { }
		[ImplicitConversation(EndMode = EndMode.End)]
		public override Silly GetIfAvailable(Guid id)
		{
			return base.GetIfAvailable(id);
		}
	}


	[ImplicitConversation]
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

		[ImplicitConversation(AttributeExclude = true)]
		public virtual void ProcessSilly()
		{
			DoSomethingPrivate();
		}
		private void DoSomethingPrivate() {}

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

		[ImplicitConversation(EndMode = EndMode.CommitAndContinue)]
		public virtual void ImmediateDelete(Silly entity)
		{
			EntityDao.MakeTransient(entity);
		}

		[ImplicitConversation(EndMode = EndMode.End)]
		public virtual void AcceptAll()
		{
			// method for use-case End
		}

		[ImplicitConversation(EndMode = EndMode.Abort)]
		public virtual void Abort()
		{
			// method for use-case Abort
		}

		#endregion

		public string PropertyOutConversation
		{
			[ImplicitConversation(AttributeExclude = true)]
			get { return null; }
		}

		public string PropertyInConversation
		{
			get { return null; }
		}

		[ImplicitConversation(AttributeExclude = true)]
		public virtual void DoSomethingNoPersistent() { }

		[PersistenceConversation]
		private IList<Silly> GetEntirelyListPrivate()
		{
			return EntityDao.GetAll();
		}
	}


	[ImplicitConversation]
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