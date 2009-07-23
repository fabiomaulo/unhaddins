﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NHibernate.Collection;
using NHibernate.Engine;
using NHibernate.Persister.Collection;
using NHibernate.Type;
using NHibernate.UserTypes;
using uNhAddIns.WPF.Collections.PersistentImpl;

namespace uNhAddIns.WPF.Collections.Types
{
    public class ObservableListType<T> : CollectionType, IUserCollectionType
    {
        public ObservableListType(string role, string foreignKeyPropertyName, bool isEmbeddedInXML)
            : base(role, foreignKeyPropertyName, isEmbeddedInXML)
        {
        }

        public ObservableListType()
            : base(string.Empty, string.Empty, false)
        {

        }
        public IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister)
        {
            return new PersistentObservableGenericList<T>(session);
        }

        public override IPersistentCollection Instantiate(ISessionImplementor session, ICollectionPersister persister, object key)
        {
            return new PersistentObservableGenericList<T>(session);
        }

        public override IPersistentCollection Wrap(ISessionImplementor session, object collection)
        {
            return new PersistentObservableGenericList<T>(session, (IList<T>) collection);
        }

        public IEnumerable GetElements(object collection)
        {
            return ((IEnumerable)collection);
        }

        public bool Contains(object collection, object entity)
        {
            return ((ICollection<T>)collection).Contains((T)entity);
        }


        public object ReplaceElements(object original, object target, ICollectionPersister persister, object owner, IDictionary copyCache, ISessionImplementor session)
        {
            return base.ReplaceElements(original, target, owner, copyCache, session);
        }

        public override object Instantiate(int anticipatedSize)
        {
            return new ObservableCollection<T>();
        }

        public override Type ReturnedClass
        {
            get
            {
                return typeof(PersistentObservableGenericList<T>);
            }
        }
    }
}