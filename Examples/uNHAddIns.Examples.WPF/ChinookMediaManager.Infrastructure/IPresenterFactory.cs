using Caliburn.PresentationFramework.ApplicationModel;

namespace ChinookMediaManager.Infrastructure
{
    public interface IPresenterFactory
    {
        T GetPresenter<T>() where T : IPresenter;
    }
}