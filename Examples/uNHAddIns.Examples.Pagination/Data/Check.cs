using System;
using NHibernate;

namespace Data
{
    public class Check
    {
        public static void Ensure(bool b, object s)
        {
            if(s == null)
            {}
        }

        public static void NotNull(object obj, string s)
        {
            if(obj == null)
                throw new ApplicationException(s);
        }
    }
}
