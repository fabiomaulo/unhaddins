using System;
using NHibernate.Engine;
using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace uNhAddIns.Listeners.AutoDirtyCheck
{
	[Serializable]
	public class ResetReadOnlyEntityUpdateListener : ISaveOrUpdateEventListener
	{
		public static readonly CascadingAction ResetReadOnly = new ResetReadOnlyCascadeAction();

		public void OnSaveOrUpdate(SaveOrUpdateEvent @event)
		{
			var session = @event.Session;
			EntityEntry entry = session.PersistenceContext.GetEntry(@event.Entity);
			if (entry != null && entry.Persister.IsMutable && entry.Status == Status.ReadOnly)
			{
				entry.BackSetStatus(Status.Loaded);
				CascadeOnUpdate(@event, entry.Persister, @event.Entity);
			}
		}

		private static void CascadeOnUpdate(SaveOrUpdateEvent @event, IEntityPersister persister, object entity)
		{
			IEventSource source = @event.Session;
			source.PersistenceContext.IncrementCascadeLevel();
			try
			{
				new Cascade(ResetReadOnly, CascadePoint.BeforeFlush, source).CascadeOn(persister, entity);
			}
			finally
			{
				source.PersistenceContext.DecrementCascadeLevel();
			}
		}
	}
}