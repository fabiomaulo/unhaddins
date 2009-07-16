using uNhAddIns.Entities;

namespace uNhAddIns.WPF.Tests.SampleDomain
{
    public class InvoiceLine : Entity
    {
        public virtual Invoice Invoice { get; set; }
    }
}