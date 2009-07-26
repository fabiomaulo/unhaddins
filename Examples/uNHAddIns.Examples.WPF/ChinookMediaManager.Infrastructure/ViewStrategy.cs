using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Core;
using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.ApplicationModel;
using Microsoft.Practices.ServiceLocation;

namespace ChinookMediaManager.Infrastructure
{

    public class ViewStrategy : DefaultViewStrategy
    {
        public ViewStrategy(IAssemblySource assemblySource, IServiceLocator serviceLocator) : base(assemblySource, serviceLocator)
        {}
        protected override IEnumerable<string> GetTypeNamesToCheck(Type modelType)
        {
            string className = modelType.Name.Substring(0, modelType.Name.IndexOf("Presen")) + "View";

            string fullClassName = string.Format("ChinookMediaManager.GUI.Views.{0}", className);

            return base.GetTypeNamesToCheck(modelType)
                .Union(new []{fullClassName});
        }
        
    }

    //public class ViewStrategy : IViewStrategy
    //{
    //    private readonly IViewStrategy _defaultViewStrategy;
    //    private readonly IServiceLocator _serviceLocator;
    //    private readonly IList<Assembly> _assemblyList = new List<Assembly>();

    //    public ViewStrategy(IAssemblySource assemblySource, IServiceLocator serviceLocator)
    //    {
    //        _defaultViewStrategy = new DefaultViewStrategy(assemblySource, serviceLocator);
    //        _serviceLocator = serviceLocator;
    //    }


    //    public object GetView(object model, DependencyObject displayLocation, object context)
    //    {
    //        try
    //        {
    //            return _defaultViewStrategy.GetView(model, displayLocation, context);
    //        }
    //        catch (Exception)
    //        {
    //            var posibleServiceName = model.GetType().Name.Substring(0, model.GetType().Name.IndexOf("Presen")) + "View";

    //            var possibleTypes = from a in _assemblyList
    //                                from type in a.GetTypes()
    //                                where type.Name == posibleServiceName && type.IsClass && !type.IsAbstract
    //                                select type;

    //            object view = _serviceLocator.GetInstance(possibleTypes.FirstOrDefault());
    //            model.WireTo(view);
    //            return view;
    //        }
    //    }

    //    public void AddViewSearchLocation(Assembly assembly)
    //    {
    //        _assemblyList.Add(assembly);
    //        _defaultViewStrategy.(assembly);
    //    }
    //}
}