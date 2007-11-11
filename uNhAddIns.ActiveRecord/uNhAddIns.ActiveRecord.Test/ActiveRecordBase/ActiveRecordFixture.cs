using System;
using NUnit.Framework;
using uNhAddIns.NH.Impl;
using uNhAddIns.Serialization;

namespace uNhAddIns.ActiveRecord.Test.ActiveRecordBase
{
    [TestFixture]
    public class ActiveRecordFixture : TestCase
    {
        public override Type[] Entities {
            get { return new Type[] {typeof (Foo)}; }
        }

        public override void OnSetUp() {
            for (int i = 1; i <= 10; i++)
            {
                Foo foo = new Foo(i, "n" + i);
                foo.Create();
            }
        }

        public override void OnTearDown() {
            Foo.DeleteAll();
        }

        [Test]
        public void Exists() {
            Assert.AreEqual(10, Foo.FindAll(new DetachedQuery("from Foo")).Length);

            for (int i = 1; i <= 10; i++)
            {
                Assert.AreEqual(true, Foo.Exists(new DetachedQuery("from Foo f where f.Id=" + i)));
            }
        }

        [Test]
        public void FindAll() {
            Foo[] list = Foo.FindAll(new DetachedQuery("from Foo"));

            Assert.AreEqual(10, list.Length);
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual("n1", list[0].Name);
            Assert.AreEqual(10, list[9].Id);
            Assert.AreEqual("n10", list[9].Name);
        }

        [Test]
        public void FindOne() {
            Foo f = Foo.FindOne(new DetachedQuery("from Foo f where f.Id=10"));

            Assert.IsNotNull(f);
            Assert.AreEqual(10, f.Id);
            Assert.AreEqual("n10", f.Name);
        }

        [Test]
        public void SlidedFindAll() {
            Foo[] list = Foo.SlicedFindAll(5, 9, new DetachedQuery("from Foo"));

            Assert.AreEqual(5, list.Length);

            Assert.AreEqual(6, list[0].Id);
            Assert.AreEqual("n6", list[0].Name);

            Assert.AreEqual(10, list[4].Id);
            Assert.AreEqual("n10", list[4].Name);
        }

        [Test]
        public void CloneWithSerialization() {
            ActiveRecord.ActiveRecordBase ar = new ActiveRecord.ActiveRecordBase();
            Cloner.Clone(ar);
        }
    }
}