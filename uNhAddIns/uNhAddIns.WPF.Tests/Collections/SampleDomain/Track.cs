using uNhAddIns.Entities;

namespace uNhAddIns.WPF.Tests.Collections.SampleDomain
{
    public class Track : Entity
    {
        public virtual string Name { get; set; }
        public virtual Album Album { get; set; }
    }
}