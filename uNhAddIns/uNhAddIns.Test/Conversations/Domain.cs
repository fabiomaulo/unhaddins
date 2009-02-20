using System;

namespace uNhAddIns.Test.Conversations
{
    [Serializable]
    public class Other
    {
        private readonly Guid _id = Guid.NewGuid();
        public virtual Guid Id
        {
            get { return _id; }
        }

        private readonly int _concurrencyId = -1;
        public virtual int ConcurrencyId
        {
            get { return _concurrencyId; }
        }

        public virtual string Name { get; set; }
    }


    [Serializable]
    public class Silly
    {
        private Guid _id = Guid.NewGuid();
        public virtual Guid Id
        {
            get { return _id; }
        }

        private readonly int _concurrencyId = -1;
        public virtual int ConcurrencyId
        {
            get { return _concurrencyId; }
        }

        public virtual string Name { get; set; }

        public virtual Other Other { get; set; }
    }
}