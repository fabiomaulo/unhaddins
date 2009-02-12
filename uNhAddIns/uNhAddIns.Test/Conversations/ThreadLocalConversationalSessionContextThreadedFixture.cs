using System.Collections.Generic;
using System.Threading;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;
using NUnit.Framework.Syntax.CSharp;
using uNhAddIns.SessionEasier;
using uNhAddIns.SessionEasier.Conversations;

namespace uNhAddIns.Test.Conversations
{
	[TestFixture]
	public class ThreadLocalConversationalSessionContextThreadedFixture: TestCase
	{
		private readonly object locker = new object();
		
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

		private void DoWork()
		{
			lock (locker)
			{
				Worker worker = new Worker();
				worker.DoWork(sessions);
			}
		}

		[Test]
		public void UseConversationInThread()
		{
			var thread = new Thread(DoWork);
			thread.Start();

			Thread.CurrentThread.Join(1000);

			using (var session = sessions.OpenSession())
			{
				var sillies = session.CreateCriteria(typeof (Silly)).List<Silly>();
				Assert.That(sillies.Count, Is.EqualTo(1));

				session.Delete("from Silly");
				session.Flush();
			}
		}

		internal class Worker
		{
			public void DoWork(ISessionFactory sessions)
			{
				var provider = new SessionFactoryProviderStub(sessions);
				var cf = new DefaultConversationFactory(provider, new NoWrappedSessionWrapper());
				var cca = new NhConversationsContainerAccessor(provider);

				var tc1 = cca.Container;
				tc1.Bind(cf.CreateConversation("1"));

				var dao = new SillyDao(sessions);
				tc1.SetAsCurrent("1");
				tc1.CurrentConversation.Start();
				var o = new Other { Name = "some other silly" };
				var e = new Silly { Name = "somebody", Other = o };
				dao.MakePersistent(e);

				tc1.CurrentConversation.End();
			}
		}
	}
}