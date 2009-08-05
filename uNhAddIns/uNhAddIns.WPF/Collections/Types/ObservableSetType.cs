using System;
using System.Collections;
using System.Collections.Generic;
using Iesi.Collections.Generic;
using NHibernate.Collection;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using NHibernate.Type;
using NHibernate.UserTypes;
using uNhAddIns.WPF.Collections.PersistentImpl;

namespace uNhAddIns.WPF.Collections.Types
{
    public class ObservableSetType<T> : CollectionType, IUserCollectionType
    {
        public ObservableSetType(string role, string foreignKeyPropertyName, bool isEmbeddedInXML)
            : base(role, foreignKeyPropertyName, isEmbeddedInXML)
        {
        }

        public ObservableSetType()
            : base(string.Empty, string.Empty, false)
        {
        }

        public override Type ReturnedClass
        {
            get { return typeof (PersistentObservableGenericSet<T>); }
        }

        #region IUserCollectionType Members

        public IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister)
        {
            return new PersistentObservableGenericSet<T>(session);
        }

        public override IPersistentCollection Wrap(ISessionImplementor session, object collection)
        {
            return new PersistentObservableGenericSet<T>(session, (ISet<T>) collection);
        }

        public IEnumerable GetElements(object collection)
        {
            return ((IEnumerable) collection);
        }

        public bool Contains(object collection, object entity)
        {
            return ((ICollection<T>) collection).Contains((T) entity);
        }


        public object ReplaceElements(object original, object target, ICollectionPersister persister, object owner,
                                      IDictionary copyCache, ISessionImplementor session)
        {
            return base.ReplaceElements(original, target, owner, copyCache, session);
        }

        public override object Instantiate(int anticipatedSize)
        {
            //return new ObservableSet<T>();
            return new EditableObservableSet<T>();
        }

        #endregion

        public override IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister,
                                                          object key)
        {
            return new PersistentObservableGenericSet<T>(session);
        }
    }
}