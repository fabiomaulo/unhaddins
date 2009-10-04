using System.ComponentModel;
using Castle.Facilities.FactorySupport;
using NUnit.Framework;
using uNhAddIns.ComponentBehaviors.Castle.Configuration;
using uNhAddIns.ComponentBehaviors.Castle.NHibernateInterceptor;
using uNhAddIns.ComponentBehaviors.Castle.Tests.SampleDomain;
using Component=Castle.MicroKernel.Registration.Component;

namespace uNhAddIns.ComponentBehaviors.Castle.Tests.NHibernateInterceptor
{
	[TestFixture]
	public class InterceptorFixture : IntegrationBaseTest
	{
		protected override void ConfigureWindsorContainer()
		{
			container.AddFacility<FactorySupportFacility>();
			container.AddFacility<ComponentBehaviorsFacility>();
			var config = new BehaviorDictionary();

			config.For<Album>().Add<NotifyPropertyChangedBehavior>().Add<EditableBehavior>();
			container.Register(Component.For<IBehaviorStore>().Instance(config));
		}

		[Test]
		public void interceptor_mode_should_work()
		{
			object id;
			using(var s = sessions.OpenSession())
			using(var tx = s.BeginTransaction())
			{
				id = s.Save(new Album {Title = "Hello World"});
				tx.Commit();
			}

			using(var s = sessions.OpenSession())
			using(var tx = s.BeginTransaction())
			{
				var album = s.Get<Album>(id);

				album.Should().Be.AssignableTo<INotifyPropertyChanged>();
				album.Should().Be.AssignableTo<IEditableObject>();
			}


		}

		protected override NHibernate.IInterceptor GetInterceptor()
		{
			return container.Resolve<ComponentBehaviorInterceptor>();
		}
	}
}