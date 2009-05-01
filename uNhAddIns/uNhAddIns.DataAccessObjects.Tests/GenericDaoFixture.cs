using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NHibernate;
using NUnit.Framework;
using uNhAddIns.DataAccessObjects.Impl;

namespace uNhAddIns.DataAccessObjects.Tests {
	[TestFixture]
	public class GenericDaoFixture : DaoBaseFixture {
		string testString = "bar";

		protected override void RegisterDao(IWindsorContainer container) {
			container.Register(Component.For<IGenericCrudDao<int, Foo>>().ImplementedBy<GenericCrudDao<int, Foo>>());
		}

		public IGenericCrudDao<int, Foo> GetDao() {
			return GetDaoFactory().GetDao<IGenericCrudDao<int, Foo>>();
		}

		public Foo CreateFoo(ref int id) {
			testString = "bar";
			var foo = new Foo {Name = testString};
			GetDao().MakePersistent(foo);
			ISession session = GetCurrentSession();
			session.Flush();
			id = foo.Id;
			session.Evict(foo);
			return foo;
		}

		[Test]
		public void Ctor() {
			Assert.Throws<ArgumentNullException>(() => new GenericDao<int, Foo>(null));
		}

		[Test]
		public void ShouldMakePersistent() {
			int id = 0;
			CreateFoo(ref id);
			ISession session = GetCurrentSession();
			var saved = session.Get<Foo>(id);
			saved.Name.Should().Equals(testString);
		}


		[Test]
		public void ShouldMakeTransient() {
			int id = 0;
			Foo foo = CreateFoo(ref id);
			IGenericCrudDao<int, Foo> dao = GetDao();
			dao.MakeTransient(foo);
			ISession session = GetCurrentSession();
			session.Flush();
			foo = session.Get<Foo>(id);
			Assert.IsNull(foo);
		}
	}
}