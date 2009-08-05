using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using NHibernate.Collection.Generic;
using NHibernate.Engine;
using NHibernate.Persister.Collection;

namespace uNhAddIns.WPF.Collections.PersistentImpl
{
    public class PersistentObservableGenericList<T> : PersistentGenericList<T>, INotifyCollectionChanged,
                                                      INotifyPropertyChanged, IEditableObject
    {
        private NotifyCollectionChangedEventHandler _collectionChanged;
        private PropertyChangedEventHandler _propertyChanged;
        private bool _isInEditMode;
        private bool _previousDirtyState;
        private IList<T> _backupBag;

        public PersistentObservableGenericList(ISessionImplementor sessionImplementor)
            : base(sessionImplementor)
        {
        }

        public PersistentObservableGenericList(ISessionImplementor sessionImplementor, IList<T> list)
            : base(sessionImplementor, list)
        {
            CaptureEventHandlers(list);
        }

        public PersistentObservableGenericList()
        {
        }

        #region INotifyCollectionChanged Members

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                Initialize(false);
                _collectionChanged += value;
            }
            remove { _collectionChanged -= value; }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                Initialize(false);
                _propertyChanged += value;
            }
            remove { _propertyChanged += value; }
        }

        #endregion

        public override void BeforeInitialize(ICollectionPersister persister, int anticipatedSize)
        {
            base.BeforeInitialize(persister, anticipatedSize);
            CaptureEventHandlers((ICollection<T>) list);
        }

        private void CaptureEventHandlers(ICollection<T> coll)
        {
            var notificableCollection = coll as INotifyCollectionChanged;
            var propertyNotificableColl = coll as INotifyPropertyChanged;

            if (notificableCollection != null)
                notificableCollection.CollectionChanged += OnCollectionChanged;

            if (propertyNotificableColl != null)
                propertyNotificableColl.PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler changed = _propertyChanged;
            if (changed != null) changed(this, e);
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyCollectionChangedEventHandler changed = _collectionChanged;
            if (changed != null) changed(this, e);
        }

        /// <summary>
        /// Begins an edit on an object.
        /// </summary>
        public void BeginEdit()
        {
            if(_isInEditMode)
                return;

            Initialize(false);
            _isInEditMode = true;
            _previousDirtyState = IsDirty;
            _backupBag = new List<T>();
            list.ForEach(obj => _backupBag.Add((T)obj));
        }

        /// <summary>
        /// Pushes changes since the last <see cref="M:System.ComponentModel.IEditableObject.BeginEdit"/> or <see cref="M:System.ComponentModel.IBindingList.AddNew"/> call into the underlying object.
        /// </summary>
        public void EndEdit()
        {
            if (!_isInEditMode)
                return;
            _isInEditMode = false;
            _backupBag = null;
        }

        /// <summary>
        /// Discards changes since the last <see cref="M:System.ComponentModel.IEditableObject.BeginEdit"/> call.
        /// </summary>
        public void CancelEdit()
        {
            if (!_isInEditMode)
                return;
            _isInEditMode = false;

            list.Clear();
            _backupBag.ForEach(item => list.Add(item));

            if (!_previousDirtyState)
                ClearDirty();

            _backupBag = null;
        }
    }
}