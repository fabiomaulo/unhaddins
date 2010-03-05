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

		protected override void RegisterAsTransient<TService, TImplementor>(IServiceLocator serviceLocator)
		{
			var windsor = serviceLocator.GetInstance<IContainerAccessor>();
			if(typeof(TService).Equals(typeof(ISillyCrudModel)))
			{
				if (typeof (TImplementor).Equals(typeof (SillyCrudModel)))
				{
					windsor.Container.Register(
					                          	Component
					                          		.For<ISillyCrudModel>()
					                          		.ImplementedBy<PostSharpSillyCrudModel>()
					                          		.LifeStyle.Transient);
					return;
				}
				if (typeof (TImplementor).Equals(typeof (InheritedSillyCrudModelWithConcreteConversationCreationInterceptor)))
				{
					windsor.Container.Register(
					                          	Component
					                          		.For<ISillyCrudModel>()
					                          		.ImplementedBy
					                          		<PostSharpInheritedSillyCrudModelWithConcreteConversationCreationInterceptor>());
					return;
				}
				
				if (typeof(TImplementor).Equals(typeof(InheritedSillyCrudModelWithConvetionConversationCreationInterceptor)))
				{
					windsor.Container.Register(
												Component
													.For<ISillyCrudModel>()
													.ImplementedBy
													<PostSharpInheritedSillyCrudModelWithConvetionConversationCreationInterceptor>());
					return;					
				}

				if (typeof (TImplementor).Equals(typeof (SillyCrudModelDefaultEnd)))
				{
					windsor.Container.Register(
					                          	Component
					                          		.For<ISillyCrudModel>()
					                          		.ImplementedBy
					                          		<PostSharpSillyCrudModelDefaultEnd>());
                    return;
				}
			}
			if (typeof(TService).Equals(typeof(ISillyCrudModelExtended)))
			{
				if (typeof(TImplementor).Equals(typeof(SillyCrudModelWithImplicit)))
				{
					windsor.Container.Register(
						Component
							.For<ISillyCrudModelExtended>()
							.ImplementedBy<PostSharpSillyCrudModelWithImplicit>());
					return;
				}
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