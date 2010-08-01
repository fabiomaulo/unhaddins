using NUnit.Framework;
using uNhAddIns.ApplicationBlocks.Entities;

namespace uNhAddIns.ApplicationBlocks.Tests
{
	[TestFixture]
	public class AbstractEntityFixture
	{
		[Test]
		public void Equality()
		{
			const int id1 = 1;
			const int id2 = 2;
			var e1 = new EntityStub { Id = id1 };
			var e2 = new EntityStub { Id = id2 };
			var e1Detached = new EntityStub { Id = id1 };

			Assert.That((object)null, Is.Not.EqualTo(e1));
			Assert.That(e2, Is.Not.EqualTo(e1));
			Assert.That(e2, Is.EqualTo(e2));
			Assert.That(e1Detached, Is.EqualTo(e1));
			Assert.That(1, Is.Not.EqualTo(e1));

			var eA = new EntityStubA { Id = id1 };
			Assert.That(eA, Is.Not.EqualTo(e1));

			var ei = new EntityStubInherit { Id = id1 };
			Assert.That(ei, Is.EqualTo(e1));
		}

		[Test]
		[Description("The HashCode does not change changing the Id")]
		public void HashDontChange()
		{
			var e = new EntityStub();
			var oldHash = e.GetHashCode();
			e.Id = 100;
			Assert.That(e.GetHashCode(), Is.EqualTo(oldHash));
		}

		[Test]
		public void HashCode()
		{
			const int id1 = 1;
			Assert.That(new EntityStub(), Is.Not.EqualTo(new EntityStub()), "twp transient should not have same hash.");
			Assert.That((new EntityStub { Id = id1 }).GetHashCode(), Is.EqualTo((new EntityStub { Id = id1 }).GetHashCode()),
									"two persistent should have same hash.");
		}
	}

	public class EntityStub : AbstractEntity<int>
	{
		public override int Id { get; set; }
	}

	public class EntityStubA : AbstractEntity<int>
	{
		public override int Id { get; set; }
	}

	public class EntityStubInherit : EntityStub { }
}