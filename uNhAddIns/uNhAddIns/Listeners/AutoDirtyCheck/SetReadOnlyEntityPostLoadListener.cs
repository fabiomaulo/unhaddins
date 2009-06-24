using System;
using NHibernate.Engine;
using NHibernate.Event;

namespace uNhAddIns.Listeners.AutoDirtyCheck
{
	[Serializable]
	public class SetReadOnlyEntityPostLoadListener : IPostLoadEventListener
	{
		public void OnPostLoad(PostLoadEvent @event)
		{
			EntityEntry entry = @event.Session.PersistenceContext.GetEntry(@event.Entity);
			entry.BackSetStatus(Status.ReadOnly);
		}
	}
}