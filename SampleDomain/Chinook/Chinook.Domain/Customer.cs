using System;

namespace Chinook.Domain
{
    public class Customer : Person
    {
        public virtual int CustomerId { get; set; }
        public virtual string Company { get; set; }
        public virtual Employee SupportRepresentant { get; set; }
        
    }
}