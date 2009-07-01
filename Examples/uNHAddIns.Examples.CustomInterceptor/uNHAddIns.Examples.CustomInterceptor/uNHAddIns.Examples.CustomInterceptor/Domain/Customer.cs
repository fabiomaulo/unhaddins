using System;
using System.ComponentModel;

namespace uNHAddIns.Examples.CustomInterceptor.Domain
{
    public class Customer : INotifyPropertyChanged
    {
        //don't raise this event... Is aop baby.
        public virtual event PropertyChangedEventHandler PropertyChanged;

        //public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
    }


    //: ICustomer
    //public interface ICustomer
    //{
    //    //TODO: remove the set_Id.
    //    Guid Id { get; set; }
    //    string Name { get; set; }
    //    string Address { get; set; }
    //}
}