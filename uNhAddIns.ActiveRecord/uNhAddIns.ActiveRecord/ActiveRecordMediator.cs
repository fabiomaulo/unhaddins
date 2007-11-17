using System;
using Castle.ActiveRecord.Framework;
using uNhAddIns.NH;

namespace uNhAddIns.ActiveRecord
{
    /// <summary>
    /// Allow programmers to use the 
    /// ActiveRecord functionality without direct reference
    /// to <see cref="ActiveRecordBase"/>
    /// </summary>
    public class ActiveRecordMediator : Castle.ActiveRecord.ActiveRecordMediator 
    {
        /// <summary>
        /// Check if any instance matches the query.
        /// </summary>
        /// <param name="targetType">target Type</param>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns><c>true</c> if an instance is found; otherwise <c>false</c>.</returns>
        public static bool Exists(Type targetType, IDetachedQuery detachedQuery) {
            return ActiveRecordBase.Exists(targetType, detachedQuery);
        }

        /// <summary>
        /// Returns all instances found for the specified type according to the criteria
        /// </summary>
        /// <param name="targetType">The target type.</param>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns>The <see cref="Array"/> of results.</returns>
        public static Array FindAll(Type targetType ,IDetachedQuery detachedQuery) {
            return ActiveRecordBase.FindAll(targetType, detachedQuery);
        }

        /// <summary>
        /// Searches and returns the first row.
        /// </summary>
        /// <param name="targetType">The target type.</param>
        /// <param name="detachedQuery">The expression query.</param>
        /// <returns>A <c>targetType</c> instance or <c>null.</c></returns>
        public static object FindFirst(Type targetType,IDetachedQuery detachedQuery) {
            return ActiveRecordBase.FindFirst(targetType, detachedQuery);
        }

        /// <summary>
        /// Searches and returns a row. If more than one is found, 
        /// throws <see cref="ActiveRecordException"/>
        /// </summary>
        /// <param name="targetType">The target type</param>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns>A <c>targetType</c> instance or <c>null</c></returns>
        public static object FindOne(Type targetType , IDetachedQuery detachedQuery) {
            return ActiveRecordBase.FindOne(targetType, detachedQuery);
        }

        /// <summary>
        /// Returns a portion of the query results (sliced)
        /// </summary>
        /// <param name="targetType">The target type.</param>
        /// <param name="firstResult">The number of the first row to retrieve.</param>
        /// <param name="maxResults">The maximum number of results retrieved.</param>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns>The sliced query results.</returns>
        public static Array SlicedFindAll(Type targetType,int firstResult, int maxResults, 
            IDetachedQuery detachedQuery) {
            return ActiveRecordBase.SlicedFindAll(targetType, firstResult, maxResults, detachedQuery);
        }
    }
}
