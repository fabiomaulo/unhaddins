using uNhAddIns.Example.AopConversationUsage.Entities;
using uNhAddIns.Example.AopConversationUsage.MultiTiers;

namespace uNhAddIns.Example.AopConversationUsage.DataAccessObjects
{
	public class DaoFactory : IDaoFactory
	{
		private readonly IServiceLocator serviceLocator;

		public DaoFactory(IServiceLocator serviceLocator)
		{
			this.serviceLocator = serviceLocator;
		}

		#region Implementation of IDaoFactory

		public ICrudDao<TEntity> GetCrudDaoOf<TEntity>() where TEntity : IEntity
		{
			return serviceLocator.Resolve<ICrudDao<TEntity>>();
		}

		public TDao GetDao<TDao>()
		{
			return serviceLocator.Resolve<TDao>();
		}

		#endregion
	}
}