using System;
using System.Windows;
using ChinookMediaManager.Infrastructure;
using Microsoft.Practices.ServiceLocation;

namespace ChinookMediaManager.GUI.Artifacts
{
    public class ViewFactory : IViewFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public ViewFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
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
            return _serviceLocator.GetInstance<TViewModel>();
        }

        #endregion

        private Window GetView<TViewModel>(TViewModel viewModel)
        {
            string viewName = typeof (TViewModel).Name.Substring(1).Replace("ViewModel", "View");
            string viewFullName = string.Format("ChinookMediaManager.GUI.Views.{0}, ChinookMediaManager.GUI", viewName);

            Type viewType = Type.GetType(viewFullName, true);

            //var view = (Window) _serviceLocator.Resolve(viewType);
            var view = (Window) _serviceLocator.GetInstance(viewType);
            view.DataContext = viewModel;
            return view;
        }
    }
}