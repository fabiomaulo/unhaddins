using Castle.ActiveRecord;
using System;
using uNhAddIns.Serialization;

namespace uNhAddIns.ActiveRecord.Test.ActiveRecordMediator
{
    [Castle.ActiveRecord.ActiveRecord]
    public class FooEntity : ICloneable
    {
        private int id;
        private string name;

        public FooEntity()
        {
        }

        public FooEntity(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        [PrimaryKey(PrimaryKeyType.Assigned)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Property]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public object Clone()
        {
            return Cloner.Clone(this);
        }
    }
}