using NHibernate;
using NHibernate.Context;
using NHibernate.Engine;

namespace uNhAddIns.SessionEasier.Conversations
{
	public class ThreadLocalConversationalSessionContext : ThreadLocalConversationContainer, ICurrentSessionContext
	{
		private bool? autoUnBind;
		private readonly ISessionFactoryImplementor factory;

		public ThreadLocalConversationalSessionContext(ISessionFactoryImplementor factory)
		{
			this.factory = factory;
		}

		#region Implementation of ICurrentSessionContext

		public ISessionFactoryImplementor Factory
		{
			get { return factory; }
		}

		public ISession CurrentSession()
		{
			return ((NhConversation) CurrentConversation).GetSession(Factory);
		}

		#endregion

		public override bool AutoUnbindAfterEndConversation
		{
			// default autoUnbind is: true
			get { return !autoUnBind.HasValue || autoUnBind.Value; }
			set { autoUnBind = value; }
		}
	}
}