using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTest
{
    public class TestUser : IUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }



        public TestUser(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return Id.ToString() + " " + FirstName + " " + LastName;
        }
    }
}
