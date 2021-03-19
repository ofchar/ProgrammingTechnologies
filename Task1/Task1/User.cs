using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class User
    {
        private string firstName;
        private string lastName;
        private string uuid;

        public User(string firstName, string lastName, string uuid)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.uuid = uuid;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Uuid { get; set; }

        public string All { get => uuid + " " + firstName + " " + lastName; }

    }
}
