using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ChinookMediaManager.Data
{
    public interface IDaoReadOnly<T> 
    {
        T Get(object id);
        T GetProxy(object id);
        void Refresh(T entity);
        IEnumerable<T> RetrieveAll();
    	IEnumerable<T> RetrieveAll(params Expression<Func<T, object>>[] expandProperties);
		IEnumerable<T> Retrieve(Expression<Func<T, bool>> predicate);
		IEnumerable<T> Retrieve(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] expandProperties);
        int Count(Expression<Func<T, bool>> predicate);
    }
}