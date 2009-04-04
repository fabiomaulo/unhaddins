using System;
using System.Web;
using System.Web.UI;
using log4net;
using NHibernate;
using uNhAddIns.SessionEasier;

namespace uNhAddIns.Web
{
	public class NHSessionWebModule : IHttpModule
	{
		private static readonly ILog log = LogManager.GetLogger(typeof (NHSessionWebModule));
		private ISessionFactoryProvider sfp;

		#region Implementation of IHttpModule

		public void Init(HttpApplication context)
		{
			log.Debug("Obtaining SessionFactoryProvider from Application context.");

			sfp = context.Application[Commons.SessionFactoryProviderKey] as ISessionFactoryProvider;
			if (sfp == null)
			{
				throw new HibernateException("Couldn't obtain SessionFactoryProvider from WebApplicationContext.");
			}

			context.BeginRequest += Application_BeginRequest;
			context.EndRequest += Application_EndRequest;
		}

		public void Dispose() {}

		private void Application_BeginRequest(object sender, EventArgs e)
		{
			if (RequestMayNeedIterationWithPersistence())
			{
				foreach (ISessionFactory factory in sfp)
				{
					factory.GetCurrentSession().BeginTransaction();
				}
			}
		}

		private static bool RequestMayNeedIterationWithPersistence()
		{
			return HttpContext.Current.Handler is Page;
		}

		private void Application_EndRequest(object sender, EventArgs e)
		{
			if (RequestMayNeedIterationWithPersistence())
			{
				foreach (ISessionFactory factory in sfp)
				{
					ISession session = factory.GetCurrentSession();
					try
					{
						session.Transaction.Commit();
					}
					catch (Exception)
					{
						session.Transaction.Rollback();
						throw;
					}
					finally
					{
						session.Dispose();
					}
				}
			}
		}

		#endregion
	}
}