using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using log4net.Config;
using log4net.Core;
using NUnit.Framework;
using NUnit.Framework.Syntax.CSharp;
using uNhAddIns.CastleAdapters.AutomaticConversationManagement;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.CastleAdapters.Tests.AutomaticConversationManagement
{
	[TestFixture]
	public class ConversationInterceptorFixture
	{
		public ConversationInterceptorFixture()
		{
			XmlConfigurator.Configure();

			InitializeWindsor();
		}

		private static WindsorContainer InitializeWindsor()
		{
			var container = new WindsorContainer();
			container.AddFacility<PersistenceConversationFacility>();
			container.Register(Component.For<IConversationContainer>().ImplementedBy<ThreadLocalConversationContainerStub>());
			container.Register(
				Component.For<IConversationsContainerAccessor>().ImplementedBy<ConversationsContainerAccessorStub>());

			container.Register(Component.For<IDaoFactory>().ImplementedBy<DaoFactoryStub>());
			container.Register(Component.For<ISillyDao>().ImplementedBy<SillyDaoStub>());
			return container;
		}

		private class TestWindsorContainerAccessor : IContainerAccessor
		{
			private readonly IWindsorContainer container;

			public TestWindsorContainerAccessor(IWindsorContainer container)
			{
				this.container = container;
			}

			#region Implementation of IContainerAccessor

			public IWindsorContainer Container
			{
				get { return container; }
			}

			#endregion
		}

		private class ConversationFactoryStub : IConversationFactory
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

		private class ConversationsContainerAccessorStub : IConversationsContainerAccessor
		{
			private readonly IContainerAccessor containerAccessor;

			public ConversationsContainerAccessorStub(IContainerAccessor containerAccessor)
			{
				this.containerAccessor = containerAccessor;
			}

			#region Implementation of IConversationsContainerAccessor

			public IConversationContainer Container
			{
				get { return containerAccessor.Container.Resolve<IConversationContainer>(); }
			}

			#endregion
		}

		private class DaoFactoryStub : IDaoFactory
		{
			private readonly IContainerAccessor containerAccessor;

			public DaoFactoryStub(IContainerAccessor containerAccessor)
			{
				this.containerAccessor = containerAccessor;
			}

			#region Implementation of IDaoFactory

			public TDao GetDao<TDao>()
			{
				return containerAccessor.Container.Resolve<TDao>();
			}

			#endregion
		}

		private class SillyDaoStub : ISillyDao
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

		private class ExceptionOnFlushConversationStub : AbstractConversation
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

		private class NoOpConversationStub : AbstractConversation
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

		private class ThreadLocalConversationContainerStub : ThreadLocalConversationContainer
		{
			public int BindedConversationCount
			{
				get { return store.Count; }
			}
		}

		[Test]
		public void ShouldUnbindOnFlushException()
		{
			using (WindsorContainer windsor = InitializeWindsor())
			{
				windsor.Register(Component.For<ISillyCrudModel>().ImplementedBy<SillyCrudModel>().LifeStyle.Transient);

				var wca = new TestWindsorContainerAccessor(windsor);
				windsor.Register(Component.For<IContainerAccessor>().Instance(wca));
				var convFactory = new ConversationFactoryStub(delegate(string id)
				                                              	{
				                                              		IConversation result = new ExceptionOnFlushConversationStub(id);
				                                              		result.OnException += ((sender, args) => args.ReThrow = false);
				                                              		return result;
				                                              	});

				windsor.Register(Component.For<IConversationFactory>().Instance(convFactory));

				var scm = windsor.Resolve<ISillyCrudModel>();
				Silly e = scm.GetIfAvailable(1);
				var conversationContainer = (ThreadLocalConversationContainerStub) windsor.Resolve<IConversationContainer>();
				Assert.That(conversationContainer.BindedConversationCount, Is.EqualTo(1),
				            "Don't start and bind the conversation inmediately");
				scm.ImmediateDelete(e);
				Assert.That(conversationContainer.BindedConversationCount, Is.EqualTo(0),
				            "Don't unbind the conversation with exception catch by custom event handler");
			}
		}

		[Test]
		public void ShouldUnbindOnEndException()
		{
			using (WindsorContainer windsor = InitializeWindsor())
			{
				windsor.Register(Component.For<ISillyCrudModel>().ImplementedBy<SillyCrudModel>().LifeStyle.Transient);
				var wca = new TestWindsorContainerAccessor(windsor);
				windsor.Register(Component.For<IContainerAccessor>().Instance(wca));
				var convFactory = new ConversationFactoryStub(delegate(string id)
				                                              	{
				                                              		IConversation result = new ExceptionOnFlushConversationStub(id);
				                                              		result.OnException += ((sender, args) => args.ReThrow = false);
				                                              		return result;
				                                              	});

				windsor.Register(Component.For<IConversationFactory>().Instance(convFactory));

				var scm = windsor.Resolve<ISillyCrudModel>();
				scm.GetIfAvailable(1);
				var conversationContainer = (ThreadLocalConversationContainerStub) windsor.Resolve<IConversationContainer>();
				Assert.That(conversationContainer.BindedConversationCount, Is.EqualTo(1),
				            "Don't start and bind the conversation inmediately");
				scm.AcceptAll();
				Assert.That(conversationContainer.BindedConversationCount, Is.EqualTo(0),
				            "Don't unbind the conversation with exception catch by custom event handler");
			}
		}

		[Test]
		public void ShouldWorkWithConcreteCtorInterceptor()
		{
			using (WindsorContainer windsor = InitializeWindsor())
			{
				windsor.Register(
					Component.For<ISillyCrudModel>().ImplementedBy<InheritedSillyCrudModelWithConcreteConversationCreationInterceptor>()
						.LifeStyle.Transient);
				var wca = new TestWindsorContainerAccessor(windsor);
				windsor.Register(Component.For<IContainerAccessor>().Instance(wca));
				var convFactory = new ConversationFactoryStub(delegate(string id)
				                                              	{
				                                              		IConversation result = new NoOpConversationStub(id);
				                                              		return result;
				                                              	});

				windsor.Register(Component.For<IConversationFactory>().Instance(convFactory));

				var scm = windsor.Resolve<ISillyCrudModel>();
				using (var ls = new LogSpy(typeof (ConversationCreationInterceptor)))
				{
					scm.GetIfAvailable(1);
					LoggingEvent[] msgs = ls.Appender.GetEvents();
					Assert.That(msgs.Length, Is.EqualTo(2));
					Assert.That(msgs[0].RenderedMessage, Text.Contains("Starting"));
					Assert.That(msgs[1].RenderedMessage, Text.Contains("Started"));
				}
			}
		}

		[Test]
		public void ShouldWorkWithServiceCtorInterceptor()
		{
			using (WindsorContainer windsor = InitializeWindsor())
			{
				windsor.Register(
					Component.For<ISillyCrudModel>().ImplementedBy<InheritedSillyCrudModelWithServiceConversationCreationInterceptor>()
						.LifeStyle.Transient);
				var wca = new TestWindsorContainerAccessor(windsor);
				windsor.Register(Component.For<IContainerAccessor>().Instance(wca));
				var convFactory = new ConversationFactoryStub(delegate(string id)
				                                              	{
				                                              		IConversation result = new NoOpConversationStub(id);
				                                              		return result;
				                                              	});

				windsor.Register(Component.For<IConversationFactory>().Instance(convFactory));

				// Registr the IConversationCreationInterceptor implementation
				windsor.Register(
					Component.For<IMyServiceConversationCreationInterceptor>().ImplementedBy<ConversationCreationInterceptor>().
						LifeStyle.Transient);

				var scm = windsor.Resolve<ISillyCrudModel>();
				using (var ls = new LogSpy(typeof (ConversationCreationInterceptor)))
				{
					scm.GetIfAvailable(1);
					LoggingEvent[] msgs = ls.Appender.GetEvents();
					Assert.That(msgs.Length, Is.EqualTo(2));
					Assert.That(msgs[0].RenderedMessage, Text.Contains("Starting"));
					Assert.That(msgs[1].RenderedMessage, Text.Contains("Started"));
				}
			}
		}
	}
}