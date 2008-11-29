using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
using NUnit.Framework.Syntax.CSharp;
using uNhAddIns.SessionEasier;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.Test.Conversations
{
	[TestFixture]
	public class ThreadLocalConversationalSessionContextFixture: TestCase
	{
		private IConversationFactory cf;
		private IConversationsContainerAccessor cca;

		protected override System.Collections.IList Mappings
		{
			get { return new[] { "Conversations.Silly.hbm.xml" }; }
		}

		protected override void Configure(Configuration configuration)
		{
			configuration.Properties[Environment.CurrentSessionContextClass] =
				typeof (ThreadLocalConversationalSessionContext).AssemblyQualifiedName;
			base.Configure(configuration);
		}

		[TestFixtureSetUp]
		public void CreateCoversationStuff()
		{
			TestFixtureSetUp();
			var provider = new SessionFactoryProviderStub(sessions);
			cf = new DefaultConversationFactory(provider, new SessionWrapperStub());
			cca = new NhConversationsContainerAccessor(provider);
		}

		[Test]
		public void ConversationUsage()
		{
			Assert.Throws<ConversationException>(() => sessions.GetCurrentSession());
			var tc1 = cca.Container;
			tc1.Bind(cf.CreateConversation("1"));
			tc1.Bind(cf.CreateConversation("2"));

			var dao = new SillyDao(sessions);
			tc1.SetAsCurrent("1");
			tc1.CurrentConversation.Start();
			var o = new Other {Name = "some other silly"};
			var e = new Silly {Name = "somebody", Other = o};
			dao.MakePersistent(e);
			tc1.CurrentConversation.Pause();

			tc1.SetAsCurrent("2");
			using (var c2 = tc1.CurrentConversation)
			{
				c2.Start();
				IList<Silly> sl = dao.GetAll();
				c2.Pause();
				Assert.That(sl.Count == 1);
				Assert.That(!NHibernateUtil.IsInitialized(sl[0].Other));
				// working with entities, even using lazy loading no cause problems
				Assert.That("some other silly", Is.EqualTo(sl[0].Other.Name));
				Assert.That(NHibernateUtil.IsInitialized(sl[0].Other));
				sl[0].Other.Name = "nobody";
				c2.Resume();
				dao.MakePersistent(sl[0]);
			}

			tc1.SetAsCurrent("1");
			tc1.CurrentConversation.Resume();
			foreach (var silly in dao.GetAll())
			{
				dao.MakeTransient(silly);
			}
			tc1.CurrentConversation.End();

			Assert.Throws<ConversationException>(() => tc1.SetAsCurrent("1"));
			Assert.Throws<ConversationException>(() => tc1.SetAsCurrent("2"));
		}
	}
}