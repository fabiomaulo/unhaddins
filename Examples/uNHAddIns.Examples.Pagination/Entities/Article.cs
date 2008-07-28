using System;

namespace Entities
{
    public class Article
    {
        private Guid id;

        public Article()
        {}

        public Article(Guid id, string firstName, string lastName, string address, string zip)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.zip = zip;
        }

        private string firstName;
        private string lastName;
        private string address;
        private string zip;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }
    }
}
