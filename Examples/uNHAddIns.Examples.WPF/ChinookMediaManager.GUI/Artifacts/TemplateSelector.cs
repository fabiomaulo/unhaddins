using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ChinookMediaManager.GUI.Artifacts
{
    public class TemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item != null)
            {
                var resources = Application.Current.MainWindow.Resources;

                var template = resources.Values.OfType<object>()
                            .Where(v => v is DataTemplate)
                            .OfType<DataTemplate>()
                            .FirstOrDefault(dt => ((Type)dt.DataType).IsAssignableFrom(item.GetType()));
                

                return template;
            }
            return base.SelectTemplate(item, container);
        }
    }
}