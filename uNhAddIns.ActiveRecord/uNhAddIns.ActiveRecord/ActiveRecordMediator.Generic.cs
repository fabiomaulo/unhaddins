using System;
using uNhAddIns.NH;

namespace uNhAddIns.ActiveRecord
{
    public class ActiveRecordMediator<T> :
        Castle.ActiveRecord.ActiveRecordMediator<T> where T : class
    {
        public static bool Exists(IDetachedQuery detachedQuery) {
            return ActiveRecordBase<T>.Exists(detachedQuery);
        }

        public static T[] FindAll(IDetachedQuery detachedQuery) {
            return ActiveRecordBase<T>.FindAll(detachedQuery);
        }

        public static T FindFirst(IDetachedQuery detachedQuery) {
            return ActiveRecordBase<T>.FindFirst(detachedQuery);
        }

        public static T FindOne(IDetachedQuery detachedQuery) {
            return ActiveRecordBase<T>.FindOne(detachedQuery);
        }

        public static T[] SlicedFindAll(int firstResult, int maxResults, IDetachedQuery detachedQuery) {
            return ActiveRecordBase<T>.SlicedFindAll(firstResult, maxResults, detachedQuery);
        }
    }
}