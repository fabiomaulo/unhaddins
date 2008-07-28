namespace uNhAddIns.Validation.Test.EntLib.Model {
    using System;
    using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

    public class Foo {

        private DateTime date;
        private string firstName;
        private int id;
        private string lastName;

        public Foo(string lastName, int id, string firstName, DateTime date) {
            this.lastName = lastName;
            this.id = id;
            this.firstName = firstName;
            this.date = date;
        }

        public Foo() {

        }

        public virtual DateTime Date {
            get { return date; }
            set { date = value; }
        }

        [StringLengthValidator(1, 30)]
        public virtual string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }

        public virtual int Id {
            get { return id; }
            set { id = value; }
        }

        [StringLengthValidator(1, 30)]
        public virtual string LastName {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}