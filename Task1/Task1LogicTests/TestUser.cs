using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Task1LogicTests
{
    internal class TestUser : IUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Uuid { get; set; }


        public TestUser(string firstName, string lastName, string uuid)
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
