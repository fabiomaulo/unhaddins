using System;
using System.ComponentModel;
using Castle.Core;
using Castle.Core.Interceptor;
using Castle.Facilities.FactorySupport;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using uNHAddIns.Examples.CustomInterceptor.Domain;
using uNHAddIns.Examples.CustomInterceptor.Infrastructure;
using uNHAddIns.Examples.CustomInterceptor.Infrastructure.MethodsInterceptors;
using Component=Castle.MicroKernel.Registration.Component;
using EntityNameInterceptor=
    uNHAddIns.Examples.CustomInterceptor.Infrastructure.MethodsInterceptors.EntityNameInterceptor;

namespace uNHAddIns.Examples.CustomInterceptor
{

    //integration.

    [TestFixture]
    public class CustomerTest : BaseTest
    {
        protected override void ConfigureWindsorContainer()
        {
            container.AddFacility<FactorySupportFacility>();
            container.Register(Component.For<NotifyPropertyChangeInterceptor>().LifeStyle.Transient);
            container.Register(Component.For<DataInterceptor>().LifeStyle.Transient);

            container.Register(Component.For<Customer>()
                        .Named(typeof(Customer).FullName)
                       .Proxy.AdditionalInterfaces(typeof(IProxiedEntity))
                       .Interceptors(new InterceptorReference(typeof(NotifyPropertyChangeInterceptor))).Anywhere
                       .LifeStyle.Transient);
 
            container.Register(Component.For<IProduct>()
                                        .Proxy.AdditionalInterfaces()
                                        .UsingFactoryMethod(() =>{
                                                        var proxyGen = new Castle.DynamicProxy.ProxyGenerator();
                                                        return (IProduct) proxyGen.CreateInterfaceProxyWithoutTarget(
                                                            typeof(IProduct), new[] { typeof(IProxiedEntity) },
                                                            new EntityNameInterceptor(typeof(IProduct).FullName),
                                                            new NotifyPropertyChangeInterceptor(), 
                                                            new DataInterceptor());
                                        }));


        }


        [Test]
        public void Product_Raise_Property_Change()
        {
            bool eventWasRaised = false;

            var product = container.Resolve<IProduct>();
            product.PropertyChanged += (sender, e) => eventWasRaised = true;

            product.Description = "a";
            eventWasRaised.Should().Be.True();
        }

        [Test]
        public void Product_Raise_Property_Change_In_NonTrascientObject()
        {
            var id = CreatePotatoesProduct();
            bool eventWasRaised = false;
            using (var session = sessions.OpenSession())
            {
                var potatoes = session.Get<IProduct>(id);

                potatoes.PropertyChanged += (sender, e) => eventWasRaised = true;

                potatoes.Description = "Maple Syrup";

                eventWasRaised.Should().Be.True();
            }
        }


        [Test]
        public void Raise_Property_Change()
        {
            bool eventWasRaised = false;

            var customer = container.Resolve<Customer>();
            customer.PropertyChanged += (sender, e) => eventWasRaised = true;

            customer.Name = "a";
            eventWasRaised.Should().Be.True();
        }

        [Test]
        public void Raise_Property_Change_In_NonTrascientObject()
        {
            var id = CreatePepeCustomer();
            bool eventWasRaised = false;
            using(var session = sessions.OpenSession())
            {
                var customer = session.Get<Customer>(id);
                
                ((INotifyPropertyChanged)customer).PropertyChanged +=
                        (sender, e) => eventWasRaised = true;

                customer.Name = "Jota";

                eventWasRaised.Should().Be.True();
            }
        }

        private Guid CreatePotatoesProduct()
        {
            Guid id;
            using (var session = sessions.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                var potatoes = ServiceLocator.Current.GetInstance<IProduct>();

                potatoes.Description = "Potatoes";
                potatoes.UnitPrice = 2;

                id = (Guid)session.Save(potatoes);
                tx.Commit();
                session.Clear();
            }
            return id;
        }
        private Guid CreatePepeCustomer()
        {
            
            Guid id;
            using(var session = sessions.OpenSession())
            using(var tx = session.BeginTransaction())
            {
                var pepe = ServiceLocator.Current.GetInstance<Customer>();

                pepe.Name = "Pepe";
                pepe.Address = "Siempreviva 1234";

                id = (Guid)session.Save(pepe);
                tx.Commit();
                session.Clear();
            }
            return id;
        }
    }
}