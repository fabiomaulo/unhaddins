using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using uNhAddIns.Adapters.CommonTests;
using uNhAddIns.Adapters.CommonTests.ConversationManagement;
using uNhAddIns.Adapters.CommonTests.Integration;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.PostSharpAdapters.Tests.AutomaticConversationManagement
{
	[TestFixture]
	public class ConversationInterceptorFixture : ConversationFixtureBase
	{
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

		[Test, Ignore("TODO update the test")]
		public override void ShouldWorkWithConventionCtorInterceptor()
		{
			base.ShouldWorkWithConventionCtorInterceptor();
		}

		[Test, Ignore("Todo update the test")]
		public override void ShouldWorkWithServiceCtorInterceptor()
		{
			base.ShouldWorkWithServiceCtorInterceptor();
		}


		[Test]
		public void ShouldSupportsExplicitMethodsInclusionOfPrivateMethod()
		{
			IServiceLocator serviceLocator = NewServiceLocator();

			RegisterAsTransient<ISillyCrudModel, PostSharpSillyCrudModelWithImplicit>(serviceLocator);

			bool startedCalled = false;
			var convFactory = new ConversationFactoryStub(delegate(string id)
			                                              	{
			                                              		IConversation result = new NoOpConversationStub(id);
			                                              		result.Started += ((s, a) => startedCalled = true);
			                                              		return result;
			                                              	});

			RegisterInstanceForService<IConversationFactory>(serviceLocator, convFactory);
			var conversationContainer =
				(ThreadLocalConversationContainerStub) serviceLocator.GetInstance<IConversationContainer>();

			var scm = serviceLocator.GetInstance<ISillyCrudModel>();

			scm.GetType().GetMethod("GetEntirelyListPrivate", BindingFlags.Instance | BindingFlags.NonPublic)
				.Invoke(scm, null);

			Assert.That(startedCalled, "An explicit method inclusion of a private member don't start the conversation.");
			Assert.That(conversationContainer.BindedConversationCount, Is.EqualTo(1),
			            "Should have one active conversation because the default mode is continue.");
			conversationContainer.Reset();
		}

		[Test]
		public void ShouldSupportNestedConversationalMethods()
		{
			IServiceLocator serviceLocator = NewServiceLocator();

			RegisterAsTransient<ISillyCrudModel, PostSharpSillyCrudModelWithImplicit>(serviceLocator);

			int startedCalledTimes = 0;
			int resumedTimes = 0;
			int pausedTimes = 0;
			var convFactory = new ConversationFactoryStub(delegate(string id)
			{
				IConversation result = new NoOpConversationStub(id);
				result.Started += (s, a) => startedCalledTimes++;
				result.Resumed += (s, a) => resumedTimes++;
				result.Paused += (s, a) => pausedTimes++;
				return result;
			});

			RegisterInstanceForService<IConversationFactory>(serviceLocator, convFactory);
			var conversationContainer =
				(ThreadLocalConversationContainerStub)serviceLocator.GetInstance<IConversationContainer>();

			var scm = serviceLocator.GetInstance<ISillyCrudModel>();

			scm.GetEntirelyList();

			Assert.That(startedCalledTimes, Is.EqualTo(1), 
						"The conversation should be started once in the former conversational method.");

			Assert.That(resumedTimes, Is.EqualTo(0),
						"The conversation should not be resumed because the second conversational method is nested.");

			Assert.That(pausedTimes, Is.EqualTo(1),
						"The conversation should be paused once because the second conversational method is nested.");

			Assert.That(conversationContainer.BindedConversationCount, Is.EqualTo(1),
						"Should have one active conversation because the default mode is continue.");

			
			conversationContainer.Reset();
		}

		[Test]
		public void PrivateMethodsShouldNotBeImplicitlyIncluded()
		{
			IServiceLocator serviceLocator = NewServiceLocator();

			RegisterAsTransient<ISillyCrudModel, PostSharpSillyCrudModelWithImplicit>(serviceLocator);

			int startedCalledTimes = 0;
			//int resumedTimes = 0;
			//int pausedTimes = 0;
			var convFactory = new ConversationFactoryStub(delegate(string id)
			                                              	{
			                                              		IConversation result = new NoOpConversationStub(id);
			                                              		result.Started += (s, a) => startedCalledTimes++;
																//result.Resumed += (s, a) => resumedTimes++;
																//result.Paused += (s, a) => pausedTimes++;
			                                              		return result;
			                                              	});

			RegisterInstanceForService<IConversationFactory>(serviceLocator, convFactory);
			var conversationContainer =
				(ThreadLocalConversationContainerStub)serviceLocator.GetInstance<IConversationContainer>();
			
			var scm = serviceLocator.GetInstance<ISillyCrudModel>();

			((PostSharpSillyCrudModelWithImplicit)scm).ProcessSilly();

			Assert.That(startedCalledTimes, Is.EqualTo(0),
			"The conversation should not be started.");

		}

		[Test]
		public void ShouldWorkWithNoopMarker()
		{
			var serviceLocator = NewServiceLocator();

			RegisterInstanceForService(serviceLocator, new NoopConversationalMarker{Noop = true});
			RegisterAsTransient<ISillyCrudModel, PostSharpSillyCrudModelWithImplicit>(serviceLocator);

			var service = new PostSharpSillyCrudModelWithImplicit(new DaoFactoryStub(serviceLocator));

			Assert.DoesNotThrow(() => service.GetEntirelyList());
			
		}

		[Test]
		public void ShouldWorkWithNoopMarkerEvenWithABadBoyContainer()
		{
			var serviceLocator = NewServiceLocator();

			RegisterInstanceForService(serviceLocator, new NoopConversationalMarker());
		
			var service = new PostSharpSillyCrudModelWithImplicit(new DaoFactoryStub(serviceLocator));

			//With a bad boy container. A container that register 
			//NoopConversationalMarker should throw because we have not registered a conversation factory.

			Assert.Throws<ActivationException>(() => service.GetEntirelyList());

		}

		[Test]
		public void ConversationalAttributeShouldBePersisted()
		{
			var serviceLocator = NewServiceLocator();

			RegisterInstanceForService(serviceLocator, new NoopConversationalMarker());
			RegisterAsTransient<ISillyCrudModel, PostSharpSillyCrudModel>(serviceLocator);

			var model = serviceLocator.GetInstance<ISillyCrudModel>();
			model.GetType().IsDefined(typeof (PersistenceConversationalAttribute), true)
				.Should("PersistMetaData should be true").Be.True();
		}


		protected override IServiceLocator NewServiceLocator()
		{
			var container = new WindsorContainer();

			var wca = new TestWindsorContainerAccessor(container);
			container.Register(Component.For<IContainerAccessor>().Instance(wca));

			// Services for this test
			var sl = new WindsorServiceLocator(container);
			container.Register(Component.For<IServiceLocator>().Instance(sl));

			container.Register(Component
							.For<IConversationContainer>()
							.ImplementedBy<ThreadLocalConversationContainerStub>());
			container.Register(
				Component.For<IConversationsContainerAccessor>().ImplementedBy<ConversationsContainerAccessorStub>());

			container.Register(Component.For<IDaoFactory>().ImplementedBy<DaoFactoryStub>());
			container.Register(Component.For<ISillyDao>().ImplementedBy<SillyDaoStub>());
			ServiceLocator.SetLocatorProvider(() => sl);
			return sl;
		}


		private readonly IDictionary<Type,Type> implementationReplacements 
			= new Dictionary<Type, Type>
			  	{
					{typeof(SillyCrudModel),typeof(PostSharpSillyCrudModel)},
					{typeof(InheritedSillyCrudModelWithConcreteConversationCreationInterceptor), typeof(PostSharpInheritedSillyCrudModelWithConcreteConversationCreationInterceptor)},
					{typeof(InheritedSillyCrudModelWithConvetionConversationCreationInterceptor), typeof(PostSharpInheritedSillyCrudModelWithConvetionConversationCreationInterceptor)},
					{typeof(SillyCrudModelDefaultEnd), typeof(PostSharpSillyCrudModelDefaultEnd)},
					{typeof(SillyCrudModelWithImplicit), typeof(PostSharpSillyCrudModelWithImplicit)}
				};

		protected override void RegisterAsTransient<TService, TImplementor>(IServiceLocator serviceLocator)
		{
			var windsor = serviceLocator.GetInstance<IContainerAccessor>();
			Type implementationReplacement;
			if(implementationReplacements.TryGetValue(typeof(TImplementor), out implementationReplacement))
			{
				windsor.Container.Register(Component.For<TService>().ImplementedBy(implementationReplacement).LifeStyle.Transient);
			}
			windsor.Container.Register(Component.For<TService>().ImplementedBy<TImplementor>().LifeStyle.Transient);
		}

		protected override void RegisterInstanceForService<T>(IServiceLocator serviceLocator, T instance)
		{
			var windsor = serviceLocator.GetInstance<IContainerAccessor>();
			windsor.Container.Register(Component.For<T>().Instance(instance));
		}
	}
}