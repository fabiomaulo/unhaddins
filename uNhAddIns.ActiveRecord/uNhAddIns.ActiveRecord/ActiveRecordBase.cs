using System;
using Castle.ActiveRecord.Framework;
using Castle.Components.Validator;
using NHibernate;
using uNhAddIns.NH;

namespace uNhAddIns.ActiveRecord
{
    public class ActiveRecordBase : Castle.ActiveRecord.ActiveRecordBase
    {
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

        protected internal static object FindFirst(Type targetType, IDetachedQuery detachedQuery) {
            Array array = SlicedFindAll(targetType, 0, 1, detachedQuery);
            if ((array != null) && (array.Length > 0))
            {
                return array.GetValue(0);
            }
            return null;
        }

        public static bool Exists(Type targetType, IDetachedQuery detachedQuery) {
            Array array = SlicedFindAll(targetType, 0, 1, detachedQuery);

            if (array.Length > 0)
                return true;
            else
                return false;
        }
    }
}