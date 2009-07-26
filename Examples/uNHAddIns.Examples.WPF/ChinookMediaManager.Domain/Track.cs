﻿using uNhAddIns.Entities;

namespace ChinookMediaManager.Domain
{
    public class Track : Entity
    {
        public virtual string Name { get; set; }
        public virtual Album Album { get; set; }
        public virtual MediaType MediaType { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual string Composer { get; set; }
        public virtual int Milliseconds { get; set; }
        public virtual int Bytes { get; set; }
        public virtual decimal UnitPrice { get; set; }
    }
}