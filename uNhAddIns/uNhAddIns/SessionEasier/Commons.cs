using System;
using Castle.DynamicProxy;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Event;

namespace uNhAddIns.SessionEasier
{
	public delegate ISession UnbindDelegate(ISession session);

	public static class Commons
	{
		public const string SessionFactoryProviderKey = "NHSession.SessionFactoryProvider";
		public const string SessionFactoryKey = "NHSession.Context.TransactedSessionContext";
		public const string NHibernateSessionKey    = "NHibernateSession";


		public static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();

		public static readonly Type[] SessionProxyInterfaces = new[]
		                                                       	{
		                                                       		typeof (ISessionWrapper), typeof (ISession),
		                                                       		typeof (ISessionImplementor), typeof (IEventSource)
		                                                       	};

	}
}