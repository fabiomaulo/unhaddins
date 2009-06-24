using System.Linq;
using NHibernate.Cfg;
using NHibernate.Event;

namespace uNhAddIns.Listeners.AutoDirtyCheck
{
	public static class ConfigurationExtensions
	{
		public static Configuration RegisterDisableAutoDirtyCheckListeners(this Configuration configuration)
		{
			EventListeners listeners = configuration.EventListeners;
			listeners.UpdateEventListeners =
				new[] {new ResetReadOnlyEntityUpdateListener()}.Concat(listeners.UpdateEventListeners).ToArray();
			listeners.DeleteEventListeners =
				new[] {new ResetReadOnlyEntityDeleteListener()}.Concat(listeners.DeleteEventListeners).ToArray();
			listeners.PostLoadEventListeners =
				new[] {new SetReadOnlyEntityPostLoadListener()}.Concat(listeners.PostLoadEventListeners).ToArray();

			return configuration;
		}
	}
}