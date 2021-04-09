using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Uuid { get; set; }


        public User(string firstName, string lastName, string uuid)
        {
            FirstName = firstName;
            LastName = lastName;
            Uuid = uuid;
        }

        public override string ToString()
        {
            return Uuid + " " + FirstName + " " + LastName;
        }
    }
}
