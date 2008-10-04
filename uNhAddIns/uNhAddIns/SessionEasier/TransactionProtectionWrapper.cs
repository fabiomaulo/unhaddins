using System;
using System.Reflection;
using Castle.Core.Interceptor;
using log4net;
using NHibernate;
using NHibernate.Util;
using IInterceptor=Castle.Core.Interceptor.IInterceptor;

namespace uNhAddIns.SessionEasier
{
	[Serializable]
	public class TransactionProtectionWrapper : IInterceptor
	{
		private static readonly ILog log = LogManager.GetLogger(typeof (TransactionProtectionWrapper));

		private readonly SessionCloseDelegate closeDelegate;
		private readonly SessionDisposeDelegate disposeDelegate;
		private readonly ISession realSession;

		public TransactionProtectionWrapper(ISession realSession, SessionCloseDelegate closeDelegate)
		{
			if (realSession == null)
			{
				throw new ArgumentNullException("realSession");
			}
			this.realSession = realSession;
			this.closeDelegate = closeDelegate;
		}

		public TransactionProtectionWrapper(ISession realSession, SessionCloseDelegate closeDelegate,
		                                    SessionDisposeDelegate disposeDelegate) : this(realSession, closeDelegate)
		{
			this.disposeDelegate = disposeDelegate;
		}

		#region IInterceptor Members

		public void Intercept(IInvocation invocation)
		{
			invocation.ReturnValue = null;
			string methodName = invocation.Method.Name;
			try
			{
				if ("get_InvocationHandler".Equals(methodName))
				{
					invocation.ReturnValue = this;
				}
				else
				{
					// If Close() is called, guarantee Unbind()
					if ("Close".Equals(methodName) || "Dispose".Equals(methodName))
					{
						if (closeDelegate != null)
							closeDelegate(realSession);
						if ("Dispose".Equals(methodName))
						{
							if (disposeDelegate != null)
								disposeDelegate(realSession);
						}
					}
					else if (IsPassThroughMethod(methodName))
					{
						// allow these to go through the the real session no matter what
					}
					else if (!realSession.IsOpen)
					{
						// essentially, if the real session is closed allow any
						// method call to pass through since the real session
						// will complain by throwing an appropriate exception;
					}
					else if (!realSession.Transaction.IsActive)
					{
						// limit the methods available if no transaction is active
						if (IsPassThroughMethodWithoutTransaction(methodName))
						{
							log.Debug("allowing method [" + methodName + "] in non-transacted context");
						}
						else if ("Reconnect".Equals(methodName) || "Disconnect".Equals(methodName))
						{
							// allow these (deprecated) methods to pass through
						}
						else
						{
							throw new HibernateException(methodName + " is not valid without active transaction");
						}
					}
					log.Debug("allowing proxied method [" + methodName + "] to proceed to real session");
					invocation.Proceed();
				}
			}
			catch (TargetInvocationException tie)
			{
				// Propagate the inner exception so that the proxy throws the same exception as the real object would 
				throw ReflectHelper.UnwrapTargetInvocationException(tie);
			}
		}

		#endregion

		protected virtual bool IsPassThroughMethodWithoutTransaction(string methodName)
		{
			return "BeginTransaction".Equals(methodName) || "get_Transaction".Equals(methodName)
			       || "set_FlushMode".Equals(methodName) || "get_SessionFactory".Equals(methodName)
			       || "get_IsConnected".Equals(methodName);
		}

		protected virtual bool IsPassThroughMethod(string methodName)
		{
			return "ToString".Equals(methodName) || "Equals".Equals(methodName) || "GetHashCode".Equals(methodName)
			       || "get_Statistics".Equals(methodName) || "get_IsOpen".Equals(methodName)
			       || "get_Timestamp".Equals(methodName);
		}
	}
}