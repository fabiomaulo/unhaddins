namespace uNhAddIns.Validation.Test.EntLib {
    using System;
    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Model;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Event;
    using NUnit.Framework;
    using uNhAddIns.Validation.EntLib;
    using Environment=uNhAddIns.Validation.Environment;

    [TestFixture]
    public class EnlibValidationFixture {
        private Configuration cfg;
        private ISessionFactory sf;

        [SetUp]
        public void Init() {
            cfg = new Configuration();
            cfg.SetProperty(Environment.HibernateValidationProvider,
                            typeof(EntLibValidator).AssemblyQualifiedName);

            ValidateEventListener validateEventListener = new ValidateEventListener();
            cfg.SetListener(ListenerType.PreInsert, validateEventListener);
            cfg.SetListener(ListenerType.PreUpdate, validateEventListener);

            cfg.Configure();

            sf = cfg.BuildSessionFactory();
        }

        private Foo GetNoValidFoo() {
            return new Foo(
                "jorge",
                1,
                "asdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdf",
                DateTime.Now);
        }

        private Foo GetValidFoo() {
            return new Foo(
                "jorge",
                2,
                "lopez",
                DateTime.Now);
        }
        
        [Test,ExpectedException(typeof(ValidationException))]
        public void InsertWithInvalidEntity() {
            
            using (ISession s = sf.OpenSession()) 
            {
                using (ITransaction tx = s.BeginTransaction()) 
                {
                    s.Save(GetNoValidFoo());
                    tx.Commit();
                }
            }
        }

        [Test]
        public void InsertWithValidEntity() {

            using (ISession s = sf.OpenSession()) 
            {
                using (ITransaction tx = s.BeginTransaction()) 
                {
                    s.Save(GetValidFoo());
                    tx.Commit();
                    Assert.AreEqual(1,s.CreateCriteria(typeof(Foo)).List().Count);
                }
            }
        }

        [Test]
        public void ValidateADetachedObject() 
        {
            Foo f = GetNoValidFoo();
            Validator<Foo> vtor = ValidationFactory.CreateValidator<Foo>();
            ValidationResults results = vtor.Validate(f);
            Assert.AreNotEqual(true, results.IsValid);
        }


    }
}