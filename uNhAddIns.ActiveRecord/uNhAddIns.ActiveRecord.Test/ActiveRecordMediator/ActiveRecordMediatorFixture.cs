using System;
using NUnit.Framework;
using uNhAddIns.NH.Impl;

namespace uNhAddIns.ActiveRecord.Test.ActiveRecordMediator
{
    [TestFixture]
    public class ActiveRecordMediatorFixture : AbstractActiveRecordTestCase
    {
        public override Type[] Entities {
            get { return new Type[] {typeof (FooEntity)}; }
        }

        public override void OnSetUp() {
            Recreate();

            for (int i = 1; i <= 10; i++)
            {
                FooEntity foo = new FooEntity(i, "n" + i);
                ActiveRecordMediator<FooEntity>.Create(foo);
            }
        }

        public override void OnTearDown() {
            ActiveRecordMediator<FooEntity>.DeleteAll();
        }

        [Test]
        public void Exists() {
            Assert.AreEqual(10, ActiveRecordMediator<FooEntity>
                                    .FindAll(new DetachedQuery("from FooEntity")).Length);

            for (int i = 1; i <= 10; i++)
            {
                Assert.AreEqual(true, ActiveRecordMediator<FooEntity>
                                          .Exists(new DetachedQuery("from FooEntity f where f.Id=" + i)));
            }
        }

        [Test]
        public void FindAll() {
            FooEntity[] list = ActiveRecordMediator<FooEntity>
                .FindAll(new DetachedQuery("from FooEntity Order By Id"));

            Assert.AreEqual(10, list.Length);
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual("n1", list[0].Name);
            Assert.AreEqual(10, list[9].Id);
            Assert.AreEqual("n10", list[9].Name);
        }

        [Test]
        public void FindOne() {
            FooEntity f = ActiveRecordMediator<FooEntity>
                .FindOne(new DetachedQuery("from FooEntity f where f.Id=10"));

            Assert.IsNotNull(f);
            Assert.AreEqual(10, f.Id);
            Assert.AreEqual("n10", f.Name);
        }

        [Test]
        public void SlidedFindAll() {
            FooEntity[] list = ActiveRecordMediator<FooEntity>
                .SlicedFindAll(5, 9, new DetachedQuery("from FooEntity"));

            Assert.AreEqual(5, list.Length);

            Assert.AreEqual(6, list[0].Id);
            Assert.AreEqual("n6", list[0].Name);

            Assert.AreEqual(10, list[4].Id);
            Assert.AreEqual("n10", list[4].Name);
        }
    }
}