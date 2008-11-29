using System;
using Castle.DynamicProxy;
using log4net;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Event;

namespace uNhAddIns.SessionEasier
{
	public delegate ISession SessionCloseDelegate(ISession session);
	public delegate void SessionDisposeDelegate(ISession session);

	public class Commons
	{
		private Commons() {}

		public const string SessionFactoryProviderKey = "NHSession.SessionFactoryProvider";
		public const string SessionFactoryKey = "NHSession.Context.TransactedSessionContext";
		public const string NHibernateSessionKey    = "NHibernateSession";


		public static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();

		public static readonly Type[] SessionProxyInterfaces = new[]
		                                                       	{
		                                                       		typeof (ISessionProxy), typeof (ISession),
		                                                       		typeof (ISessionImplementor), typeof (IEventSource)
		                                                       	};


	}
}