using System;
using System.Collections.Generic;
using PostSharp.Extensibility;
using uNhAddIns.Adapters.CommonTests;
using uNhAddIns.Adapters.CommonTests.ConversationManagement;

namespace uNhAddIns.PostSharpAdapters.Tests.AutomaticConversationManagement
{
	[PersistenceConversational(AttributeInheritance = MulticastInheritance.Multicast)]
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

	[PersistenceConversational(ConversationCreationInterceptor = typeof(ConversationCreationInterceptor))]
	public class PostSharpInheritedSillyCrudModelWithConcreteConversationCreationInterceptor 
		: ISillyCrudModel
	{
		public PostSharpInheritedSillyCrudModelWithConcreteConversationCreationInterceptor(IDaoFactory factory) 
		{ }

		public IList<Silly> GetEntirelyList()
		{
			throw new NotImplementedException();
		}

		public Silly GetIfAvailable(Guid id)
		{
			return new Silly(id);
		}

		public Silly Save(Silly entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(Silly entity)
		{
			throw new NotImplementedException();
		}

		public void ImmediateDelete(Silly entity)
		{
			throw new NotImplementedException();
		}

		public void AcceptAll()
		{
			throw new NotImplementedException();
		}

		public void Abort()
		{
			throw new NotImplementedException();
		}
	}

	
	public class PostSharpSillyCrudModelDefaultEnd : PostSharpSillyCrudModel
	{
		public PostSharpSillyCrudModelDefaultEnd(IDaoFactory factory) : base(factory) { }

		[PersistenceConversation(ConversationEndMode = EndMode.End)]
		public override Silly GetIfAvailable(Guid id)
		{
			return base.GetIfAvailable(id);
		}
	}


	[PersistenceConversational]
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

		[PersistenceConversation(Exclude = true)]
		public virtual void ProcessSilly()
		{
			DoSomethingPrivate();
		}

// ReSharper disable MemberCanBeMadeStatic.Local
		private void DoSomethingPrivate()
// ReSharper restore MemberCanBeMadeStatic.Local
		{
			
		}

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


	[PersistenceConversational]
	public class PostSharpInheritedSillyCrudModelWithConvetionConversationCreationInterceptor : PostSharpSillyCrudModel
	{
		public PostSharpInheritedSillyCrudModelWithConvetionConversationCreationInterceptor(IDaoFactory factory) 
			: base(factory) { }
		
		public override Silly GetIfAvailable(Guid id)
		{
			return base.GetIfAvailable(id);
		}
	}



	public class Base
	{
		public object Something { get; set; }
	}

	public class TypedBase<T> : Base
	{
		public new T Something
		{
			get { return (T)base.Something; }
			set { base.Something = value; }
		}
	}

	[PersistenceConversational]
	public class StringSample : TypedBase<string>
	{
		public StringSample()
		{
			Something = "aaa";
		}
	}



}