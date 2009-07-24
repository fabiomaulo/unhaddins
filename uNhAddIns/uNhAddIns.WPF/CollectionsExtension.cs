using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace uNhAddIns.WPF
{
    public static class CollectionsExtension
    {
        public static ObservableCollection<T> AsObservable<T>(this IEnumerable<T> coll)
        {
            return new ObservableCollection<T>(coll);
        }
    }
}