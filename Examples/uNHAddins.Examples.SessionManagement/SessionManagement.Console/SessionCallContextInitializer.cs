using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using NHibernate;
using SessionManagement.Infrastructure.InversionOfControl;
using SessionManagement.WCF.Host;

namespace SessionManagement.WCF.Host
{
	public class SessionCallContextInitializer : ICallContextInitializer
	{
		#region ICallContextInitializer Members

		public object BeforeInvoke(InstanceContext instanceContext, IClientChannel channel, Message message)
		{
			var session = IoC.Resolve<ISessionFactory>().GetCurrentSession();
			session.BeginTransaction();
			OperationContext.Current.Extensions.Add(new ApplicationContext(session));
			return null;
		}

		public void AfterInvoke(object correlationState)
		{
			ApplicationContext.Session.Transaction.Commit();
			ApplicationContext.CloseSession();
		}

		#endregion
	}
}