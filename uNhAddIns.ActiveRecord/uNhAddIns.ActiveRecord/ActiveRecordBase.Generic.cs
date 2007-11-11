using System;
using Castle.ActiveRecord.Framework;
using uNhAddIns.NH;

namespace uNhAddIns.ActiveRecord
{
    /// <summary>
    /// Base class for all ActiveRecord Generic classes. 
    /// Implements all the functionality to simplify the code on the subclasses.
    /// Provide search methods with detached queries support.
    /// </summary>
    /// <typeparam name="T">The type of the entity</typeparam>
    [Serializable]
    public class ActiveRecordBase<T>
        : Castle.ActiveRecord.ActiveRecordBase<T>
        where T : class
    {
        /// <summary>
        /// Returns all instances found for the specified type according to the criteria
        /// </summary>
        /// <param name="detachedQuery">The query expression.</param>
        /// <returns>All entities that match the query</returns>
        public static T[] FindAll(IDetachedQuery detachedQuery) {
            return (T[]) ActiveRecordBase.FindAll(typeof (T), detachedQuery);
        }

        /// <summary>
        /// Searches and returns a row. If more than one is found, 
        /// throws <see cref="ActiveRecordException"/>
        /// <param name="detachedQuery">The query expression</param>
        /// </summary>
        /// <returns>A <c>targetType</c> instance or <c>null</c></returns>
        public static T FindOne(IDetachedQuery detachedQuery) {
            return (T) ActiveRecordBase.FindOne(typeof (T), detachedQuery);
        }

        /// <summary>
        /// Returns a portion of the query results (sliced)
        /// </summary>
        /// <param name="firstResult">The number of the first row to retrieve.</param>
        /// <param name="maxResults">The maximum number of results retrieved.</param>
        /// <returns>The sliced query results.</returns>
        /// <param name="detachedQuery">The query expression</param>
        public static T[] SlicedFindAll(int firstResult, int maxResults, IDetachedQuery detachedQuery) {
            return (T[]) ActiveRecordBase.SlicedFindAll(typeof (T), firstResult, maxResults, detachedQuery);
        }

        /// <summary>
        /// Searches and returns the first row. 
        /// </summary>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns>A <c>targetType</c> instance or <c>null.</c></returns>
        public static T FindFirst(IDetachedQuery detachedQuery)
        {
            return (T)ActiveRecordBase.FindFirst(typeof(T), detachedQuery);
        }

        /// <summary>
        /// Check if any instance matching the query exists in the database.
        /// </summary>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns>true if an instance is found; otherwise false.</returns>
        public static bool Exists(IDetachedQuery detachedQuery) {
            return ActiveRecordBase.Exists(typeof (T), detachedQuery);
        }
    }
}