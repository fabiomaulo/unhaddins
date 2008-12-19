using System.Collections.Generic;
using NHibernate;
using SessionManagement.Data.Repositories;
using SessionManagement.Domain;

namespace SessionManagement.Data.NH.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }

		public IList<Product> GetAllProducts()
		{
			IQuery query = Session.GetNamedQuery("GetAllProductsOrderedByCode");
			return query.List<Product>();
		}
	}
}
