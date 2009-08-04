using Caliburn.PresentationFramework.ApplicationModel;
using Castle.Windsor;

namespace ChinookMediaManager.Infrastructure
{
    public class PresenterFactory : IPresenterFactory
    {
        private readonly IWindsorContainer _windsorContainer;

        public PresenterFactory(IWindsorContainer windsorContainer)
        {
            _windsorContainer = windsorContainer;
        }

        #region IPresenterFactory Members

        public T GetPresenter<T>() where T : IPresenter
        {
            return _windsorContainer.Resolve<T>();
        }

        #endregion
    }
}