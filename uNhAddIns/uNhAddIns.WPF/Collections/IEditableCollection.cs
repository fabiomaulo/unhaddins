using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace uNhAddIns.WPF.Collections
{
    public interface IEditableCollection<T> : IEnumerable<T>, IEditableObject, INotifyCollectionChanged
    {}
}