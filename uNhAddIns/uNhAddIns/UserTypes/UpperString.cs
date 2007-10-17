using System;
using System.Data;
using System.Data.Common;
using NHibernate.SqlTypes;

using NHibernate.UserTypes;

namespace uNHAddIns.UserTypes
{
    /// <summary>
    /// Convert the String to Upper when the object it's saved
    /// or when you get it from the base.
    /// </summary>
    public class UpperString : IUserType
    {
        public bool Equals(object x, object y)
        {
            if (x == y)
            {
                return true;
            }
            if (x == null)
            {
                return false;
            }
            return x.Equals(y);
        }

        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            if (rs.IsDBNull(rs.GetOrdinal(names[0]))) return null;

            return rs[names[0]].ToString().ToUpper();
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            DbParameter parameter = (DbParameter)cmd.Parameters[index];

            if (value == null)
            {
                parameter.Value = DBNull.Value;
                return;
            }
            
            ((IDataParameter) cmd.Parameters[index]).Value = ((String)value).ToUpper();
        }

        public object DeepCopy(object value)
        {
            if(value == null) return null;
            return string.Copy((String) value);
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            throw new NotImplementedException();
        }

        public object Disassemble(object value)
        {
            throw new NotImplementedException();
        }

        public SqlType[] SqlTypes
        {
            get 
            {
                SqlType[] types = new SqlType[1];
                types[0] = new SqlType(DbType.String);
                return types;
            }
        }

        public Type ReturnedType
        {
            get { return typeof (String); }
        }

        public bool IsMutable
        {
            get { return false; }
        }
    }
}