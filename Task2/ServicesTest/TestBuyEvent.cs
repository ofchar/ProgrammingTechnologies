using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTest
{
    public class TestBuyEvent : Event
    {
        public TestBuyEvent(int id, DateTime timestamp, int amount, int catalogId, int userId)
            : base(id, timestamp, amount, catalogId, userId, false) { }
    }
}
