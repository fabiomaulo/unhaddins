using Castle.DynamicProxy;
using NHibernate;

namespace uNhAddIns.SessionEasier
{
	public class SessionWrapper : ISessionWrapper
	{
		private static readonly ProxyGenerator proxyGenerator = new ProxyGenerator();

		#region Implementation of ISessionWrapper

		public ISession Wrap(ISession realSession, SessionCloseDelegate closeDelegate, SessionDisposeDelegate disposeDelegate)
		{
			var wrapper = new TransactionProtectionWrapper(realSession, closeDelegate, disposeDelegate);
			var wrapped =
				(ISession)
				proxyGenerator.CreateInterfaceProxyWithTarget(typeof (ISession), Commons.SessionProxyInterfaces, realSession,
				                                              wrapper);
			return wrapped;
		}

		public bool IsWrapped(ISession session)
		{
			if (session == null)
			{
				return false;
			}
			var sessionProxy = session as ISessionProxy;
			// try to make sure we don't wrap and already wrapped session
			return sessionProxy != null && sessionProxy.InvocationHandler != null
			       && sessionProxy.InvocationHandler is TransactionProtectionWrapper;
		}

		#endregion
	}
}