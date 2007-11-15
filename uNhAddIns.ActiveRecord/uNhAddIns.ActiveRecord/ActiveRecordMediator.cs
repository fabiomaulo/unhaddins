using System;
using uNhAddIns.NH;

namespace uNhAddIns.ActiveRecord
{
    public class ActiveRecordMediator : Castle.ActiveRecord.ActiveRecordMediator 
    {
        public static bool Exists(Type targetType, IDetachedQuery detachedQuery) {
            return ActiveRecordBase.Exists(targetType, detachedQuery);
        }
        public static Array FindAll(Type targetType ,IDetachedQuery detachedQuery) {
            return ActiveRecordBase.FindAll(targetType, detachedQuery);
        }
        public static object FindFirst(Type targetType,IDetachedQuery detachedQuery) {
            return ActiveRecordBase.FindFirst(targetType, detachedQuery);
        }
        public static object FindOne(Type targetType , IDetachedQuery detachedQuery) {
            return ActiveRecordBase.FindOne(targetType, detachedQuery);
        }
        public static Array SlicedFindAll(Type targetType,int firstResult, int maxResults, 
            IDetachedQuery detachedQuery) {
            return ActiveRecordBase.SlicedFindAll(targetType, firstResult, maxResults, detachedQuery);
        }
    }
}
