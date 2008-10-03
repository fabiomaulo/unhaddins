using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
using NUnit.Framework.Syntax.CSharp;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.Test.Conversations
{
	[TestFixture]
	public class ThreadLocalConversationalSessionContextFixture: TestCase
	{
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

		[Test, Ignore("Not supported yet.")]
		public void ConversationUsage()
		{
			Assert.Throws<ConversationException>(() => sessions.GetCurrentSession());

			var dao = new SillyDao(sessions);
			using (var c = new NhConversation(new SessionFactoryProviderStub(sessions)))
			{
				c.Start();
				var o = new Other { Name = "some other silly" };
				var e = new Silly { Name = "somebody", Other = o };
				dao.MakePersistent(e);
			}

			using (var c = new NhConversation(new SessionFactoryProviderStub(sessions)))
			{
				c.Start();
				IList<Silly> sl = dao.GetAll();
				c.Pause();
				Assert.That(sl.Count == 1);
				Assert.That(!NHibernateUtil.IsInitialized(sl[0].Other));
				// working with entities, even using lazy loading
				Assert.That("some other silly", Is.EqualTo(sl[0].Other.Name));
				Assert.That(NHibernateUtil.IsInitialized(sl[0].Other));
				sl[0].Other.Name = "nobody";
				c.Resume();
				dao.MakePersistent(sl[0]);
			}

			using (var c = new NhConversation(new SessionFactoryProviderStub(sessions)))
			{
				c.Start();
				IList<Silly> sl = dao.GetAll();
				foreach (var silly in sl)
				{
					dao.MakeTransient(silly);
				}
				c.End();
			}
		}
	}
}