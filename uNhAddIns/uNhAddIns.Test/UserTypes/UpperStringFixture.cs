using System.Collections;
using NHibernate;
using NUnit.Framework;

namespace uNhAddIns.Test.UserTypes
{
    [TestFixture]
    public class UpperStringFixture : TestCase
    {
        protected override IList Mappings
        {
            get { return new string[] { "UserTypes.UpperStringMappings.hbm.xml" }; }
        }

        protected override void OnTearDown()
        {
            using (ISession s = OpenSession())
            {
                s.Delete("from Foo");
                s.Flush();
            }
        }

        [Test]
        public void SaveObject()
        {
            Foo f = new Foo(1, "Astor Piazolla", "tango");

            using (ISession s = OpenSession())
            {
                s.Save(f);
                s.Flush();
            }

            using (ISession s = OpenSession())
            {
                Foo upperFoo = s.Get<Foo>(1);
                
                Assert.AreEqual(1,upperFoo.Id);
                Assert.AreEqual("Astor Piazolla", upperFoo.Name);
                Assert.AreEqual("TANGO", upperFoo.Description);
            }
        }

        [Test]
        public void SaveNullProperty()
        {
            Foo f = new Foo(2, "Pat Metheny", null);

            using (ISession s = OpenSession())
            {
                s.Save(f);
                s.Flush();
            }

            using (ISession s = OpenSession())
            {
                Foo upperFoo = s.Get<Foo>(2);

                Assert.AreEqual(2, upperFoo.Id);
                Assert.AreEqual("Pat Metheny", upperFoo.Name);
                Assert.IsNull(upperFoo.Description);
            }

        }
    }
}