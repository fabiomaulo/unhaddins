using uNhAddIns.Entities;

namespace uNhAddIns.WPF.Tests.Collections.SampleDomain
{
    public class InvoiceLine : Entity
    {
        public virtual Invoice Invoice { get; set; }
    }
}