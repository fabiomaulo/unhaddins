using System;
using System.ComponentModel;

namespace uNHAddIns.Examples.CustomInterceptor.Domain
{
    /// <summary>
    /// Look there is not *any* real implementation.
    /// </summary>
    public interface IProduct : INotifyPropertyChanged, IEditableObject
    {
        string Description { get; set; }
        decimal UnitPrice { get; set; }
    }
}