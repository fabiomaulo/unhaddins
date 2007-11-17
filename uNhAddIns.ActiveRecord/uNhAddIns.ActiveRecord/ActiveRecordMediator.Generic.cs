using System;
using Castle.ActiveRecord.Framework;
using uNhAddIns.NH;

namespace uNhAddIns.ActiveRecord
{
    /// <summary>
    /// Allow programmers to use the ActiveRecord functionality without direct reference to <c>ActiveRecordBase</c>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ActiveRecordMediator<T> :
        Castle.ActiveRecord.ActiveRecordMediator<T> where T : class
    {
        /// <summary>
        /// Check if any instance matches the query.
        /// </summary>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns><c>true</c> if an instance is found; otherwise <c>false</c>.</returns>
        public static bool Exists(IDetachedQuery detachedQuery) {
            return ActiveRecordBase<T>.Exists(detachedQuery);
        }

        /// <summary>
        /// Returns all instances found for the specified type according to the criteria
        /// </summary>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns>The <see cref="Array"/> of results.</returns>
        public static T[] FindAll(IDetachedQuery detachedQuery) {
            return ActiveRecordBase<T>.FindAll(detachedQuery);
        }

        /// <summary>
        /// Searches and returns the first row.
        /// </summary>
        /// <param name="detachedQuery">The expression query.</param>
        /// <returns>A <c>targetType</c> instance or <c>null.</c></returns>
        public static T FindFirst(IDetachedQuery detachedQuery) {
            return ActiveRecordBase<T>.FindFirst(detachedQuery);
        }

        /// <summary>
        /// Searches and returns a row. If more than one is found, 
        /// throws <see cref="ActiveRecordException"/>
        /// </summary>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns>A <c>targetType</c> instance or <c>null</c></returns>
        public static T FindOne(IDetachedQuery detachedQuery) {
            return ActiveRecordBase<T>.FindOne(detachedQuery);
        }

        /// <summary>
        /// Returns a portion of the query results (sliced)
        /// </summary>
        /// <param name="firstResult">The number of the first row to retrieve.</param>
        /// <param name="maxResults">The maximum number of results retrieved.</param>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns>The sliced query results.</returns>
        public static T[] SlicedFindAll(int firstResult, int maxResults, IDetachedQuery detachedQuery) {
            return ActiveRecordBase<T>.SlicedFindAll(firstResult, maxResults, detachedQuery);
        }
    }
}