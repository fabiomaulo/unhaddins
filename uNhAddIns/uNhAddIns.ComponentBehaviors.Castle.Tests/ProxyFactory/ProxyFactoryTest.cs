using System.ComponentModel;
using Castle.Windsor;
using NUnit.Framework;
using uNhAddIns.ComponentBehaviors.Castle.Configuration;
using uNhAddIns.ComponentBehaviors.Castle.ProxyFactory;
using uNhAddIns.ComponentBehaviors.Castle.Tests.SampleDomain;
using uNhAddIns.TestUtils.NhIntegration;
using Component=Castle.MicroKernel.Registration.Component;

namespace uNhAddIns.ComponentBehaviors.Castle.Tests.ProxyFactory
{
    [TestFixture]
    public class ProxyFactoryTest : IntegrationBaseTest
    {
        protected override void ConfigureWindsorContainer()
        {
            //add the component behavior facility
            container.AddFacility<ComponentBehaviorsFacility>();

            //configure the behavior metadata
            var config = new DefaultBehaviorStore();
            config.SetBehaviors(typeof(Album), Behaviors.NotifiableBehavior);
            container.Register(Component.For<IBehaviorStore>().Instance(config));

            //register the proxyfactoryfactory.
            container.Register(Component.For<ComponentProxyFactoryFactory>().LifeStyle.Singleton);
            
            //TODO: fix this.
            container.Register(Component.For<IWindsorContainer>().Instance(container));
        }

        [Test]
        public void load_should_work()
        {
            int id=0;
            sessions.EncloseInTransaction(s => {id = (int)s.Save(new Album{Title = "a"});});

            using(var s  = sessions.OpenSession())
            using(var tx = s.BeginTransaction())
            {
                var album = s.Load<Album>(id);
                album.Should().Be.AssignableTo<INotifyPropertyChanged>();


                //simple test
                bool eventWasRaised = false;
                ((INotifyPropertyChanged) album).PropertyChanged += (sender, args) =>
                                                                        {
                                                                            if (args.PropertyName.Equals("Title"))
                                                                                eventWasRaised = true;
                                                                        };

                album.Title = "new title";
                eventWasRaised.Should().Be.True();
                //

                tx.Commit();
            }
            
        }

        protected override string GetProxyFactoryFactory()
        {
            //this fixture uses the following proxyfactoryfactory
            return typeof(ComponentProxyFactoryFactory).AssemblyQualifiedName;
        }
    }
}