namespace uNhAddIns.Validation {
    using NHibernate.Event;

    public interface IValidator {
        bool IsValid(PreInsertEvent @event);
        bool IsValid(PreUpdateEvent @event);
    }
}