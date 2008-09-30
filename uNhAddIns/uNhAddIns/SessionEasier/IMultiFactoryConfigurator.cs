using NHibernate.Cfg;

namespace uNhAddIns.SessionEasier
{
	public interface IMultiFactoryConfigurator
	{
		Configuration[] Configure();
	}
}