using System;
using System.ComponentModel;
using Castle.Facilities.FactorySupport;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using NUnit.Framework;
using uNHAddIns.Examples.CustomInterceptor.Domain;
using uNHAddIns.Examples.CustomInterceptor.Infrastructure;
using uNHAddIns.Examples.CustomInterceptor.Infrastructure.MethodsInterceptors;
using Component=Castle.MicroKernel.Registration.Component;

namespace uNHAddIns.Examples.CustomInterceptor
{
    //integration.

    [Explicit]
    [TestFixture]
    public class NotifyPropertyChangedTest : BaseTest
    {
        protected override void ConfigureWindsorContainer()
        {
            container.AddFacility<FactorySupportFacility>();
            container.Register(Component.For<PropertyChangeInterceptor>().LifeStyle.Transient);
            container.Register(Component.For<EntityNameInterceptor>()
                                   .LifeStyle.Transient);

            container.Register(Component.For<Customer>()
                                   .NotifyOnPropertyChange()
                                   .EnableNhibernateEntityCompatibility()
                                   .LifeStyle.Transient);


            //If you use Common Datastore you don't need to set NhibernateEntityCompatibility.
            container.Register(Component.For<IProduct>()
                                   .NotifyOnPropertyChange()
                                   .TargetIsCommonDatastore());
        }


        private Guid CreatePotatoesProduct()
        {
            Guid id;
            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var potatoes = ServiceLocator.Current.GetInstance<IProduct>();

                potatoes.Description = "Potatoes";
                potatoes.UnitPrice = 2;

                id = (Guid) session.Save(potatoes);
                tx.Commit();
                session.Clear();
            }
            return id;
        }

        private Guid CreatePepeCustomer()
        {
            Guid id;
            using (ISession session = sessions.OpenSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                var pepe = ServiceLocator.Current.GetInstance<Customer>();

                pepe.Name = "Pepe";
                pepe.Address = "Siempreviva 1234";

                id = (Guid) session.Save(pepe);
                tx.Commit();
                session.Clear();
            }
            return id;
        }

        [Test]
        public void can_raise_propertychanged()
        {
            bool eventWasRaised = false;

            var customer = container.Resolve<Customer>();
            customer.PropertyChanged += (sender, e) => eventWasRaised = true;

            customer.Name = "a";
            eventWasRaised.Should().Be.True();
        }

        [Test]
        public void can_raise_propertychanged_in_nontrascientobject()
        {
            Guid id = CreatePepeCustomer();
            bool eventWasRaised = false;
            using (ISession session = sessions.OpenSession())
            {
                var customer = session.Get<Customer>(id);

                ((INotifyPropertyChanged) customer).PropertyChanged +=
                    (sender, e) => eventWasRaised = true;

                customer.Name = "Jota";

                eventWasRaised.Should().Be.True();
            }
        }

        [Test]
        public void can_raise_propertychanged_with_nonimplementedinterface()
        {
            bool eventWasRaised = false;

            var product = container.Resolve<IProduct>();
            product.PropertyChanged += (sender, e) => eventWasRaised = true;

            product.Description = "a";
            eventWasRaised.Should().Be.True();
        }

        [Test]
        public void can_raise_with_nonimplementedinterface_in_nontrascientobject()
        {
            Guid id = CreatePotatoesProduct();
            bool eventWasRaised = false;
            using (ISession session = sessions.OpenSession())
            {
                var potatoes = session.Get<IProduct>(id);

                potatoes.PropertyChanged += (sender, e) => eventWasRaised = true;

                potatoes.Description = "Maple Syrup";

                eventWasRaised.Should().Be.True();
            }
        }
    }
}