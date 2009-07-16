using uNhAddIns.Entities;

namespace uNhAddIns.WPF.Tests.SampleDomain
{
    public class Track : Entity
    {
        public virtual string Name { get; set; }
        public virtual Album Album { get; set; }
    }
}