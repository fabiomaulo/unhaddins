using NHibernate;

namespace uNhAddIns.SessionEasier
{
	public class NoWrappedSessionWrapper : ISessionWrapper
	{
		#region Implementation of ISessionWrapper

		public ISession Wrap(ISession realSession, SessionCloseDelegate closeDelegate, SessionDisposeDelegate disposeDelegate)
		{
			return realSession;
		}

		public bool IsWrapped(ISession session)
		{
			return session != null;
		}

		#endregion
	}
}