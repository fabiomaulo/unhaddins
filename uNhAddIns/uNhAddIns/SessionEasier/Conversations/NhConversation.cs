using System;
using System.Collections.Generic;
using log4net;
using NHibernate;
using NHibernate.Engine;

namespace uNhAddIns.SessionEasier.Conversations
{
	[Serializable]
	public class NhConversation : AbstractConversation
	{
		// TODO : use System.Transaction to enclose multi DB conversation
		// NOTE : NH2.1 are supporting ambient transactions (even if the implementation is not complete)
		private const string sessionsContextKey = "uNhAddIns.Conversations.NHSessions";
		[NonSerialized] protected static readonly ILog log = LogManager.GetLogger(typeof (NhConversation));
		[NonSerialized] private readonly ISessionFactoryProvider factoriesProvider;

		public NhConversation(ISessionFactoryProvider factoriesProvider)
		{
			if (factoriesProvider == null)
			{
				throw new ArgumentNullException("factoriesProvider");
			}
			this.factoriesProvider = factoriesProvider;
		}

		public NhConversation(ISessionFactoryProvider factoriesProvider, string id) : base(id)
		{
			if (factoriesProvider == null)
			{
				throw new ArgumentNullException("factoriesProvider");
			}
			this.factoriesProvider = factoriesProvider;
		}

		#region Overrides of AbstractConversation

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				IDictionary<ISessionFactory, ISession> sessions = GetFromContext();
				foreach (var pair in sessions)
				{
					pair.Value.Dispose();
				}
				sessions.Clear();
			}
		}

		protected override void DoStart()
		{
			DoResume();
		}

		protected override void DoPause()
		{
			IDictionary<ISessionFactory, ISession> sessions = GetFromContext();
			foreach (var pair in sessions)
			{
				FlushAndCommit(pair.Value);
			}
		}

		private static void FlushAndCommit(ISession session)
		{
			if (session.Transaction != null && session.Transaction.IsActive)
			{
				session.Flush();
				session.Transaction.Commit();
			}
		}

		protected override void DoResume()
		{
			IDictionary<ISessionFactory, ISession> sessions = GetFromContext();
			if (sessions.Count > 0)
			{
				var factoriesToRebind = new List<ISessionFactory>(5);
				foreach (var pair in sessions)
				{
					ISession s = pair.Value;
					if (s != null && s.IsOpen)
					{
						if (!s.IsConnected)
						{
							s.Reconnect();
						}
					}
					else
					{
						factoriesToRebind.Add(pair.Key);
					}
				}
				foreach (var factory in factoriesToRebind)
				{
					Bind(OpenNewSessionFor(factory));					
				}
			}
			else
			{
				// Bind a session for each SessionFactory
				foreach (var factory in factoriesProvider)
				{
					Bind(OpenNewSessionFor(factory));
				}
			}
			foreach (var pair in sessions)
			{
				pair.Value.BeginTransaction();
			}
		}

		protected virtual ISession OpenNewSessionFor(ISessionFactory factory)
		{
			ISession session = BuildSession((ISessionFactoryImplementor) factory);
			if (session.FlushMode != FlushMode.Never)
			{
				log.Debug("Disabling automatic flushing of the Session");
				session.FlushMode = FlushMode.Never;
			}

			// wrap the session in the transaction-protection proxy
			session = Wrap(session);
			return session;
		}

		protected virtual ISession Wrap(ISession session)
		{
			var wrapper = new TransactionProtectionWrapper(session, x => x);
			var wrapped =
				(ISession)
				Commons.ProxyGenerator.CreateInterfaceProxyWithTarget(typeof(ISession), Commons.SessionProxyInterfaces, session,
																															wrapper);
			return wrapped;
		}

		protected virtual ISession BuildSession(ISessionFactoryImplementor factory)
		{
			return factory.OpenSession(null, false, false, factory.Settings.ConnectionReleaseMode);
		}

		protected override void DoEnd()
		{
			IDictionary<ISessionFactory, ISession> sessions = GetFromContext();
			foreach (var pair in sessions)
			{
				ISession session = pair.Value;
				if (session != null && session.IsOpen)
				{
					FlushAndCommit(session);
					session.Close();
				}
			}
		}

		#endregion

		protected IDictionary<ISessionFactory, ISession> GetFromContext()
		{
			object result;
			if (!Context.TryGetValue(sessionsContextKey, out result))
			{
				result = new Dictionary<ISessionFactory, ISession>(2);
				Context[sessionsContextKey] = result;
			}
			return (IDictionary<ISessionFactory, ISession>) result;
		}

		public virtual ISession GetSession(ISessionFactory sessionFactory)
		{
			IDictionary<ISessionFactory, ISession> sessions = GetFromContext();
			ISession result;
			if (!sessions.TryGetValue(sessionFactory, out result))
			{
				throw new ConversationException("The conversation was not started or was disposed or the SessionFactoryProvider don't manage it.");
			}
			return result;
		}

		public void Bind(ISession session)
		{
			ISessionFactory factory = session.SessionFactory;
			CleanupAnyOrphanedSession(factory);
			DoBind(session, factory);
		}

		private void CleanupAnyOrphanedSession(ISessionFactory factory)
		{
			ISession orphan = DoUnbind(factory);
			if (orphan != null && orphan.IsOpen)
			{
				log.Warn("Already session bound on call to Bind(); make sure you clean up your sessions!");
				try
				{
					if (orphan.Transaction != null && orphan.Transaction.IsActive)
					{
						try
						{
							orphan.Transaction.Rollback();
						}
						catch (Exception t)
						{
							log.Debug("Unable to rollback transaction for orphaned session", t);
						}
					}
					orphan.Close();
				}
				catch (Exception t)
				{
					log.Debug("Unable to close orphaned session", t);
				}
			}
		}

		private ISession DoUnbind(ISessionFactory factory)
		{
			IDictionary<ISessionFactory, ISession> sessionDic = GetFromContext();
			ISession session = null;
			if (sessionDic != null)
			{
				sessionDic.TryGetValue(factory, out session);
				sessionDic[factory] = null;
			}
			return session;
		}

		public void Unbind(ISession session)
		{
			DoUnbind(session.SessionFactory);
		}

		private void DoBind(ISession session, ISessionFactory factory)
		{
			IDictionary<ISessionFactory, ISession> sessions = GetFromContext();
			sessions[factory] = session;
		}
	}
}