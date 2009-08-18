namespace ChinookMediaManager.Infrastructure
{
    public interface IViewFactory
    {
        TViewModel ShowView<TViewModel>();
        TViewModel ResolveViewModel<TViewModel>();



    }
}