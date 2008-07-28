namespace uNhAddIns.Validation.EntLib {
    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using NHibernate.Event;

    /// <summary>
    /// Validator for use with Enterprise Library Application Block
    /// http://www.codeplex.com/entlib
    /// </summary>
    public class EntLibValidator : AbstractValidator {
        
        private ValidationResults results;
        
        public override bool IsValid(PreInsertEvent @event) {
            entity = @event.Entity;
            Validate(insertRuleSet);
            return results.IsValid;
        }

        public override bool IsValid(PreUpdateEvent @event) {
            entity = @event.Entity;
            Validate(updateRuleSet);
            return results.IsValid;
        }

        public void Validate(string ruleSet) {
            
            Validator vtor;

            if (string.IsNullOrEmpty(ruleSet))
                vtor = ValidationFactory.CreateValidator(entity.GetType());
            else
                vtor = ValidationFactory.CreateValidator(entity.GetType(), ruleSet);
            
            results = vtor.Validate(entity);
        }
    }
}
