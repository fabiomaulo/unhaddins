using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace uNhAddIns.WPF.Collections
{
    /// <summary>
    /// A ObservableSet that implements IEditableObject
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EditableObservableSet<T> : ObservableSet<T>, IEditableCollection<T>
    {
        private bool _isInEditMode ;
        private IList<T> _backupList;


        /// <summary>
        /// Begins an edit on an object.
        /// </summary>
        public void BeginEdit()
        {
            if (_isInEditMode)
                throw new InvalidOperationException("The collection is already in edit mode");

            _isInEditMode = true;
            
            _backupList = new List<T>();

            this.ForEach(_backupList.Add);
        }

        /// <summary>
        /// Pushes changes since the last <see cref="M:System.ComponentModel.IEditableObject.BeginEdit"/> or <see cref="M:System.ComponentModel.IBindingList.AddNew"/> call into the underlying object.
        /// </summary>
        public void EndEdit()
        {
            if(!_isInEditMode)
                throw new InvalidOperationException("EndEdit without BeginEdit");
            _isInEditMode = false;
            _backupList = null;
        }

        /// <summary>
        /// Discards changes since the last <see cref="M:System.ComponentModel.IEditableObject.BeginEdit"/> call.
        /// </summary>
        public void CancelEdit()
        {
            if(!_isInEditMode)
                throw new InvalidOperationException("CancelEdit without BeginEdit");

            _isInEditMode = false;
            Clear();
            _backupList.ForEach(obj => Add(obj));
        }
    }
}