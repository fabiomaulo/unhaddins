using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using SessionManagement.Data.Repositories;
using SessionManagement.Domain;

namespace SessionManagement.Data.NH.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

		public IList<Product> GetAllProducts()
		{
			var criteria = DetachedCriteria.For<Product>().AddOrder(Order.Asc("Code"));
			return criteria.GetExecutableCriteria(Session).List<Product>();
		}
	}
}
