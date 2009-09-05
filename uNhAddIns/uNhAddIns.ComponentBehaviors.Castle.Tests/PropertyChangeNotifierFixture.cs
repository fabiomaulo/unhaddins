using System.ComponentModel;
using Castle.Core;
using Castle.Facilities.FactorySupport;
using NHibernate;
using NUnit.Framework;
using uNhAddIns.ComponentBehaviors.Castle.Tests.SampleDomain;
using Component=Castle.MicroKernel.Registration.Component;

namespace uNhAddIns.ComponentBehaviors.Castle.Tests
{
    [TestFixture]
    public class PropertyChangeNotifierFixture : IntegrationBaseTest
    {
        protected override void ConfigureWindsorContainer()
        {
            container.AddFacility<FactorySupportFacility>();

            container.Register(Component.For<PropertyChangedInterceptor>()
                                   .LifeStyle.Transient);

            container.Register(Component.For<GetEntityNameInterceptor>()
                                   .LifeStyle.Transient);

            container.Register(Component.For<Album>()
                                   .Proxy.AdditionalInterfaces(typeof (INotifyPropertyChanged))
                                   .Interceptors(new InterceptorReference(typeof (PropertyChangedInterceptor))).Anywhere
                                   .LifeStyle.Transient);
        }


        private int CreateNewAlbum()
        {
            int id;
            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var album = new Album();
                album.Title = "The dark side of the moon";
                id = (int) session.Save(album);
                tx.Commit();
            }
            return id;
        }


        [Test]
        public void can_raise_propertychanged()
        {
            bool eventWasRaised = false;

            var album = container.Resolve<Album>();
            ((INotifyPropertyChanged) album).PropertyChanged +=
                (sender, e) =>
                    {
                        eventWasRaised = true;
                        e.PropertyName.Should().Be.EqualTo("Title");
                    };

            album.Title = "dark side";
            eventWasRaised.Should().Be.True();
        }


        [Test]
        public void should_not_raise_propertychanged_when_value_doesnt_change()
        {
            bool eventWasRaised = false;

            var album = container.Resolve<Album>();
            album.Title = "dark side";

            ((INotifyPropertyChanged)album).PropertyChanged +=
                (sender, e) => eventWasRaised = true;;

            album.Title = "dark side";
            eventWasRaised.Should().Be.False();
        }


        [Test]
        public void can_raise_propertychanged_in_nontransientobject()
        {
            int id = CreateNewAlbum();
            bool eventWasRaised = false;

            using (ISession session = sessions.OpenSession())
            {
                var album = session.Get<Album>(id);

                ((INotifyPropertyChanged) album).PropertyChanged +=
                    (sender, e) =>
                        {
                            if(e.PropertyName.Equals("Title"))
                            {
                                eventWasRaised = true;
                                album.Title.Should().Be.EqualTo("dark side");
                            }
                        };

                album.Title = "dark side";

                eventWasRaised.Should().Be.True();
            }
        }

        [Test]
        public void can_raise_property_changed_for_readonly_property()
        {
            container.Register(Component.For<Person1>()
                                  .Proxy.AdditionalInterfaces(typeof(INotifyPropertyChanged))
                                  .Interceptors(new InterceptorReference(typeof(PropertyChangedInterceptor))).Anywhere
                                  .LifeStyle.Transient);

            var person = container.Resolve<Person1>();
            bool eventWasRaised = false;

            ((INotifyPropertyChanged)person).PropertyChanged +=
                    (sender, e) =>
                    {
                        if(e.PropertyName == "FullName")
                        {
                            person.FullName.Should().Be.EqualTo("Jose ");
                            eventWasRaised = true;
                        }
                            
                    };

            person.FirstName = "Jose";
            eventWasRaised.Should().Be.True();

        }


    }

    public class Person1
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set; }
        public virtual string FullName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }
    }

}