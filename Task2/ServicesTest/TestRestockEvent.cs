using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTest
{
    public class TestRestockEvent : Event
    {
        public TestRestockEvent(int id, DateTime timestamp, int amount, int catalogId, int userId)
            : base(id, timestamp, amount, catalogId, userId, true) { }
    }
}
