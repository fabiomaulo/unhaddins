using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Core;
using Caliburn.PresentationFramework.ApplicationModel;
using Microsoft.Practices.ServiceLocation;

namespace ChinookMediaManager.Infrastructure
{
    public class ViewStrategy : DefaultViewStrategy
    {
        public ViewStrategy(IAssemblySource assemblySource, IServiceLocator serviceLocator)
            : base(assemblySource, serviceLocator)
        {
        }

        protected override IEnumerable<string> GetTypeNamesToCheck(Type modelType)
        {
            string className = modelType.Name.Substring(0, modelType.Name.IndexOf("Presen")) + "View";

            string fullClassName = string.Format("ChinookMediaManager.GUI.Views.{0}", className);

            return base.GetTypeNamesToCheck(modelType)
                .Union(new[] {fullClassName});
        }
    }
}