using System;
using System.Collections.Generic;
using log4net;
using Microsoft.Practices.ServiceLocation;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.Adapters.CommonTests.ConversationManagement
{
	public class ConversationFactoryStub : IConversationFactory
	{
		private readonly Func<string, IConversation> creator;

		public ConversationFactoryStub(Func<string, IConversation> creator)
		{
			this.creator = creator;
		}

		#region Implementation of IConversationFactory

		public IConversation CreateConversation()
		{
			throw new NotImplementedException();
		}

		public IConversation CreateConversation(string conversationId)
		{
			return creator(conversationId);
		}

		#endregion
	}

	public class ConversationsContainerAccessorStub : IConversationsContainerAccessor
	{
		private readonly IServiceLocator serviceLocator;

		public ConversationsContainerAccessorStub(IServiceLocator serviceLocator)
		{
			this.serviceLocator = serviceLocator;
		}

		#region Implementation of IConversationsContainerAccessor

		public IConversationContainer Container
		{
			get { return serviceLocator.GetInstance<IConversationContainer>(); }
		}

		#endregion
	}

	public class DaoFactoryStub : IDaoFactory
	{
		private readonly IServiceLocator serviceLocator;

		public DaoFactoryStub(IServiceLocator serviceLocator)
		{
			this.serviceLocator = serviceLocator;
		}

		#region Implementation of IDaoFactory

		public TDao GetDao<TDao>()
		{
			return serviceLocator.GetInstance<TDao>();
		}

		#endregion
	}

	public class SillyDaoStub : ISillyDao
	{
		#region Implementation of ISillyDao

		public Silly Get(int id)
		{
			return new Silly {Id = id};
		}

		public IList<Silly> GetAll()
		{
			return new List<Silly>(new[] {new Silly {Id = 1}});
		}

		public Silly MakePersistent(Silly entity)
		{
			return entity;
		}

		public void MakeTransient(Silly entity) {}

		#endregion
	}

	public class ExceptionOnFlushConversationStub : AbstractConversation
	{
		public ExceptionOnFlushConversationStub(string id) : base(id) {}

		#region Overrides of AbstractConversation

		protected override void Dispose(bool disposing) {}

		protected override void DoStart() {}

		protected override void DoFlushAndPause()
		{
			throw new NotImplementedException();
		}

		protected override void DoPause() {}

		protected override void DoResume() {}

		protected override void DoEnd()
		{
			throw new NotImplementedException();
		}

		protected override void DoAbort() {}

		#endregion
	}

	public class NoOpConversationStub : AbstractConversation
	{
		public NoOpConversationStub(string id) : base(id) {}

		#region Overrides of AbstractConversation

		protected override void Dispose(bool disposing) {}

		protected override void DoStart() {}

		protected override void DoFlushAndPause() {}

		protected override void DoPause() {}

		protected override void DoResume() {}

		protected override void DoEnd() {}

		protected override void DoAbort() {}

		#endregion
	}

	public class ThreadLocalConversationContainerStub : ThreadLocalConversationContainer
	{
		public int BindedConversationCount
		{
			get { return store.Count; }
		}
	}

	[PersistenceConversational(ConversationCreationInterceptor = typeof (ConversationCreationInterceptor))]
	public class InheritedSillyCrudModelWithConcreteConversationCreationInterceptor : SillyCrudModel
	{
		public InheritedSillyCrudModelWithConcreteConversationCreationInterceptor(IDaoFactory factory) : base(factory) {}
	}

	public class ConversationCreationInterceptor : IMyServiceConversationCreationInterceptor
	{
		public ILog Log
		{
			get { return LogManager.GetLogger(typeof (ConversationCreationInterceptor)); }
		}

		#region Implementation of IConversationCreationInterceptor

		public void Configure(IConversation conversation)
		{
			conversation.Starting += ((x, y) => Log.Debug("Starting"));
			conversation.Started += ((x, y) => Log.Debug("Started"));
		}

		#endregion
	}

	public interface IMyServiceConversationCreationInterceptor : IConversationCreationInterceptor {}

	[PersistenceConversational(ConversationCreationInterceptor = typeof (IMyServiceConversationCreationInterceptor))]
	public class InheritedSillyCrudModelWithServiceConversationCreationInterceptor : SillyCrudModel
	{
		public InheritedSillyCrudModelWithServiceConversationCreationInterceptor(IDaoFactory factory) : base(factory) {}
	}

	[PersistenceConversational]
	public class InheritedSillyCrudModelWithConvetionConversationCreationInterceptor : SillyCrudModel
	{
		public InheritedSillyCrudModelWithConvetionConversationCreationInterceptor(IDaoFactory factory) : base(factory) {}
	}

	public class ConvetionConversationCreationInterceptor :
		IConversationCreationInterceptorConvention<InheritedSillyCrudModelWithConvetionConversationCreationInterceptor>
	{
		public ILog Log
		{
			get { return LogManager.GetLogger(typeof (ConvetionConversationCreationInterceptor)); }
		}

		#region Implementation of IConversationCreationInterceptor

		public void Configure(IConversation conversation)
		{
			conversation.Starting += ((x, y) => Log.Debug("Starting with convention"));
			conversation.Started += ((x, y) => Log.Debug("Started with convention"));
		}

		#endregion
	}
}