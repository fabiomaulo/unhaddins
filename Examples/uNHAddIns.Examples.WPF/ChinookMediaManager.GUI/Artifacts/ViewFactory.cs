using System;
using System.Windows;
using Castle.Windsor;
using ChinookMediaManager.Domain;
using ChinookMediaManager.GUI.ViewModels;
using ChinookMediaManager.Infrastructure;

namespace ChinookMediaManager.GUI.Artifacts
{
    public class ViewFactory : IViewFactory
    {
        private readonly IWindsorContainer _container;

        public ViewFactory(IWindsorContainer container)
        {
            _container = container;
        }

        #region IViewFactory Members

        public TViewModel ShowView<TViewModel>()
        {
            var viewModel = ResolveViewModel<TViewModel>();
            Window view = GetView(viewModel);
            view.Show();
            Application.Current.MainWindow = view;
            return viewModel;
        }

        public TViewModel ResolveViewModel<TViewModel>()
        {
            return _container.Resolve<TViewModel>();
        }

        private Window GetView<TViewModel>(TViewModel viewModel)
        {
            var viewName = typeof (TViewModel).Name.Substring(1).Replace("ViewModel", "View");
            string viewFullName = string.Format("ChinookMediaManager.GUI.Views.{0}, ChinookMediaManager.GUI", viewName);

            var viewType = Type.GetType(viewFullName, true);

            var view = (Window) _container.Resolve(viewType);
            view.DataContext = viewModel;
            return view;
        }

       


        #endregion
    }
}