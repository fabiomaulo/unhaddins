using uNhAddIns.NH;

namespace uNhAddIns.ActiveRecord
{
    public class ActiveRecordBase<T>
        : Castle.ActiveRecord.ActiveRecordBase<T>
        where T : class
    {
        public static T[] FindAll(IDetachedQuery detachedQuery) {
            return (T[]) ActiveRecordBase.FindAll(typeof (T), detachedQuery);
        }

        public static T FindOne(IDetachedQuery detachedQuery) {
            return (T) ActiveRecordBase.FindOne(typeof (T), detachedQuery);
        }

        public static T[] SlicedFindAll(int firstResult, int maxResults, IDetachedQuery detachedQuery) {
            return (T[]) ActiveRecordBase.SlicedFindAll(typeof (T), firstResult, maxResults, detachedQuery);
        }

        public static T FindFirst(IDetachedQuery detachedQuery)
        {
            return (T)ActiveRecordBase.FindFirst(typeof(T), detachedQuery);
        }

        public static bool Exists(IDetachedQuery detachedQuery) {
            return ActiveRecordBase.Exists(typeof (T), detachedQuery);
        }
    }
}