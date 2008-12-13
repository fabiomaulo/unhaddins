using NHibernate;
using SessionManagement.Data.Repositories;
using SessionManagement.Domain;

namespace SessionManagement.Data.NH.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(ISessionFactory sessionFactory) : base(sessionFactory) { }
	}
}
