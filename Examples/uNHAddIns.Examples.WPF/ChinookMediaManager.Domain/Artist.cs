using System;
using uNhAddIns.Entities;

namespace ChinookMediaManager.Domain
{
    public class Artist : Entity
    {
        public virtual string Name { get; set; }
    }
}