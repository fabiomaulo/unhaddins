using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using NHibernate;
using NHibernate.Engine;

namespace uNhAddIns.WPF
{
    public static class CollectionsExtension
    {
        public static ObservableCollection<T> AsObservable<T>(this IEnumerable<T> coll)
        {
            return new ObservableCollection<T>(coll);
        }

        /// <summary>
        /// untested.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="coll"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public static ObservableCollection<T> AsObservableWithAutoPersistence<T>(this IEnumerable<T> coll, ISession session)
        {
            var observableCollection = new ObservableCollection<T>(coll);

            observableCollection.CollectionChanged 
                += (sender, args) =>
                {
                    switch (args.Action)
                    {
                        case NotifyCollectionChangedAction.Add:
                            foreach (var newItem in args.NewItems)
                            {
                                session.Save(newItem);
                            }
                            break;
                        case NotifyCollectionChangedAction.Remove:
                            foreach (var newItem in args.NewItems)
                            {
                                session.Delete(newItem);
                            }
                            break;
                        case NotifyCollectionChangedAction.Reset:
                            //ouch
                            break;
                        default:
                            break;
                    }
                };
            return observableCollection;
        }
    }
}