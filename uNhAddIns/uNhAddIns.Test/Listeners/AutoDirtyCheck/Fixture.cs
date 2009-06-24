using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using uNhAddIns.TestUtils.NhIntegration;
using NUnit.Framework;
using uNhAddIns.Listeners.AutoDirtyCheck;

namespace uNhAddIns.Test.Listeners.AutoDirtyCheck
{
	[TestFixture]
	public class Fixture : FunctionalTestCase
	{
		private class DisableAutoDirtyCheckSettings:DefaultFunctionalTestSettings
		{
			public DisableAutoDirtyCheckSettings(IMappingsLoader mappingLoader) : base(mappingLoader) {}

			public override void Configure(Configuration configuration)
			{
				base.Configure(configuration);
				configuration.SetProperty(Environment.GenerateStatistics, "true");
				configuration.SetProperty(Environment.BatchSize, "10");
				configuration.RegisterDisableAutoDirtyCheckListeners();
			}
		}

		public Fixture()
		{
			var ml = new NamespaceMappingsLoader(GetType().Assembly, GetType().Namespace);
			var s = new DisableAutoDirtyCheckSettings(ml);
			Settings = s;
		}


		public void FillDb()
		{
			SessionFactory.EncloseInTransaction(session =>
																						{
																							for (int i = 0; i < 10; i++)
																							{
																								var reptileFamily =
																									ReptileFamilyBuilder.StartRecording().WithChildren(2).Build();

																								session.Save(reptileFamily);
																							}

																							for (int i = 0; i < 10; i++)
																							{
																								var humanFamily = HumanFamilyBuilder.StartRecording().WithChildren(1).Build();

																								session.Save(humanFamily);
																							}
																						});
		}

		public void CleanDb()
		{
			SessionFactory.EncloseInTransaction(session =>
																						{
																							session.Delete("from HumanFamily");
																							session.Delete("from ReptilesFamily");
																						});
		}

		[Test]
		public void ShouldNotAutoUpdate()
		{
			FillDb();

			using (ISession s = SessionFactory.OpenSession())
			using (ITransaction tx = s.BeginTransaction())
			{
				var reptiles = s.CreateQuery("from ReptilesFamily")
					.Future<Family<Reptile>>();

				var humans = s.CreateQuery("from HumanFamily")
					.Future<Family<Human>>();

				ModifyAll(reptiles);
				ModifyAll(humans);

				SessionFactory.Statistics.Clear();

				s.Update(reptiles.First());
				s.Update(humans.First());

				tx.Commit();
			}

			SessionFactory.Statistics.EntityUpdateCount
				.Should().Be.EqualTo(7);

			CleanDb();
		}

		[Test]
		public void ShouldUpdateCollection()
		{
			SessionFactory.EncloseInTransaction(session =>
																						{
																							var reptileFamily =
																								ReptileFamilyBuilder.StartRecording().WithChildren(2).Build();
																							session.Save(reptileFamily);
																						});

			Family<Reptile> reptil;
			SessionFactory.EncloseInTransaction(session =>
																						{
																							reptil =
																								session.CreateQuery("from ReptilesFamily").SetMaxResults(1).UniqueResult
																									<Family<Reptile>>();

																							reptil.Children.Remove(reptil.Children.First());
																							session.Update(reptil);
																						});

			SessionFactory.EncloseInTransaction(session =>
																						{
																							reptil =
																								session.CreateQuery("from ReptilesFamily").SetMaxResults(1).UniqueResult
																									<Family<Reptile>>();

																							reptil.Children.Count.Should().Be.EqualTo(1);
																						});

			CleanDb();
		}

		[Test]
		public void ShouldDelete()
		{
			SessionFactory.EncloseInTransaction(session =>
																						{
																							var reptileFamily =
																								ReptileFamilyBuilder.StartRecording().WithChildren(2).Build();
																							session.Save(reptileFamily);
																						});

			SessionFactory.EncloseInTransaction(session =>
																						{
																							var reptil =
																								session.CreateQuery("from ReptilesFamily").SetMaxResults(1).UniqueResult
																									<Family<Reptile>>();

																							session.Delete(reptil);
																						});

			IList instancesInDb = null;
			SessionFactory.EncloseInTransaction(session => instancesInDb = session.CreateQuery("from System.Object").List());

			instancesInDb.Count.Should().Be.EqualTo(0);
		}

		public static void ModifyAll<T>(IEnumerable<Family<T>> families) where T : Animal
		{
			int i = 0;
			foreach (var family in families)
			{
				i++;
				family.Father.Description = family.Father.Description + i;
				family.Mother.Description = family.Father.Description + i;
				foreach (var child in family.Children)
				{
					child.Description = child.Description + " of " + i;
				}
			}
		}
	}
}