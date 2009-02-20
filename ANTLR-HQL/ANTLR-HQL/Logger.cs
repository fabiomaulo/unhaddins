using System;

namespace NHibernate.Hql.Ast.ANTLR
{
    // TODO - For now, this is just a placeholder to enable the Java
    // to be ported over.  Once tht bit's finished, replace this with whatever logging NH uses
    public class Logger
    {
        public bool isDebugEnabled()
        {
            return false;
        }

		public bool isTraceEnabled()
		{
			return false;
		}

		public void trace(string str)
		{
		}

		public void trace(string str, Exception e)
		{
		}

        public void debug(string str)
        {
        }

		public void debug(string str, Exception e)
		{
		}

        public void warn(string str)
        {
        }

		public void error(string str)
		{
		}
	}
}
