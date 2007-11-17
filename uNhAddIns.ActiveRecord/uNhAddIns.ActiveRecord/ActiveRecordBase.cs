using System;
using Castle.ActiveRecord.Framework;
using Castle.Components.Validator;
using NHibernate;
using uNhAddIns.NH;

namespace uNhAddIns.ActiveRecord
{
    /// <summary>
    /// Base class for all ActiveRecord classes. Implements 
    /// all the functionality to simplify the code on the 
    /// subclasses.
    /// </summary>
    [Serializable]
    public class ActiveRecordBase : Castle.ActiveRecord.ActiveRecordBase
    {
        /// <summary>
        /// Returns all instances found for the specified type according to the criteria
        /// </summary>
        /// <param name="targetType">The target type.</param>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns>The <see cref="Array"/> of results.</returns>
        public static Array FindAll(Type targetType, IDetachedQuery detachedQuery) {
            Array array;
            //This it's internal at ActiveRecord,implementation to do.
            //EnsureInitialized(targetType); 
            ISession session = holder.CreateSession(targetType);
            try
            {
                IQuery executableQuery = detachedQuery.GetExecutableQuery(session);
                array = SupportingUtils.BuildArray(targetType, executableQuery.List());
            }
            catch (ValidationException)
            {
                holder.FailSession(session);
                throw;
            }
            catch (Exception exception)
            {
                holder.FailSession(session);
                throw new ActiveRecordException("Could not perform FindAll for " + targetType.Name, exception);
            }
            finally
            {
                holder.ReleaseSession(session);
            }
            return array;
        }

        /// <summary>
        /// Returns a portion of the query results (sliced)
        /// </summary>
        /// <param name="targetType">The target type.</param>
        /// <param name="firstResult">The number of the first row to retrieve.</param>
        /// <param name="maxResults">The maximum number of results retrieved.</param>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns>The sliced query results.</returns>
        public static Array SlicedFindAll(Type targetType, int firstResult, int maxResults, IDetachedQuery detachedQuery) {
            Array array;
            //This it's internal at ActiveRecord,implementation to do.
            //EnsureInitialized(targetType); 
            ISession session = holder.CreateSession(targetType);
            try
            {
                IQuery executableQuery = detachedQuery.GetExecutableQuery(session);
                executableQuery.SetFirstResult(firstResult);
                executableQuery.SetMaxResults(maxResults);
                array = SupportingUtils.BuildArray(targetType, executableQuery.List());
            }
            catch (ValidationException)
            {
                holder.FailSession(session);
                throw;
            }
            catch (Exception exception)
            {
                holder.FailSession(session);
                throw new ActiveRecordException("Could not perform SlicedFindAll for " + targetType.Name, exception);
            }
            finally
            {
                holder.ReleaseSession(session);
            }
            return array;
        }

        /// <summary>
        /// Searches and returns a row. If more than one is found, 
        /// throws <see cref="ActiveRecordException"/>
        /// </summary>
        /// <param name="targetType">The target type</param>
        /// <param name="detachedQuery">The query expression</param>
        /// <returns>A <c>targetType</c> instance or <c>null</c></returns>
        public static object FindOne(Type targetType, IDetachedQuery detachedQuery) {
            Array array = SlicedFindAll(targetType, 0, 2, detachedQuery);
            if (array.Length > 1)
            {
                throw new ActiveRecordException(
                    string.Concat(
                        new object[]
                            {targetType.Name, ".FindOne returned ", array.Length, " rows. Expecting one or none"}));
            }
            if (array.Length != 0)
            {
                return array.GetValue(0);
            }
            return null;
        }

        /// <summary>
        /// Searches and returns the first row.
        /// </summary>
        /// <param name="targetType">The target type.</param>
        /// <param name="detachedQuery">The expression query.</param>
        /// <returns>A <c>targetType</c> instance or <c>null.</c></returns>
        public static object FindFirst(Type targetType, IDetachedQuery detachedQuery) {
            Array array = SlicedFindAll(targetType, 0, 1, detachedQuery);
            if ((array != null) && (array.Length > 0))
            {
                return array.GetValue(0);
            }
            return null;
        }

        /// <summary>
        /// Check if there is any records in the db for the target type
        /// </summary>
        /// <param name="targetType">The target type.</param>
        /// <param name="detachedQuery"></param>
        /// <returns><c>true</c> if there's at least one row</returns>
        public static bool Exists(Type targetType, IDetachedQuery detachedQuery) {
            Array array = SlicedFindAll(targetType, 0, 1, detachedQuery);

            if (array.Length > 0)
                return true;
            else
                return false;
        }
    }
}