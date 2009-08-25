using Castle.Core.Interceptor;
using NHibernate;
using NHibernate.Engine;
using IInterceptor=Castle.Core.Interceptor.IInterceptor;

namespace uNhAddIns.ComponentBehaviors.Castle
{
    /// <summary>
    /// Nhibernate Editable Behavior. <br />
    /// EndEdit => Call Session.Persist()
    /// CancelEdit => Call Session.
    /// </summary>
    public class NhEditableBehaviorInterceptor : IInterceptor
    {
        private readonly ISessionFactoryImplementor _sessionFactory;

        public NhEditableBehaviorInterceptor(ISessionFactoryImplementor sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        private ISession CurrentSession
        {
            get { return _sessionFactory.GetCurrentSession(); }
        }

        #region IInterceptor Members

        public void Intercept(IInvocation invocation)
        {
            switch (invocation.Method.Name)
            {
                case "BeginEdit":
                    //TODO: should look?
                    return;
                case "CancelEdit":
                    CurrentSession.Refresh(invocation.InvocationTarget);
                    return;
                case "EndEdit":
                    CurrentSession.Persist(invocation.InvocationTarget);
                    return;
                default:
                    invocation.Proceed();
                    break;
            }
        }

        #endregion
    }
}