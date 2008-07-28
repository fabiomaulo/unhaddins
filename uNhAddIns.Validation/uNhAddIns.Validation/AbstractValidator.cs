namespace uNhAddIns.Validation {
    using NHibernate.Event;

    public abstract class AbstractValidator : IValidator {
        protected object entity;
        protected string updateRuleSet;
        protected string insertRuleSet;

        public void SetInsertRuleSet(string ruleSetName) {
            insertRuleSet = ruleSetName;
        }

        public void SetUpdateRuleSet(string ruleSetName) {
            updateRuleSet = ruleSetName;
        }

        public abstract bool IsValid(PreInsertEvent @event);
        public abstract bool IsValid(PreUpdateEvent @event);
    }
}