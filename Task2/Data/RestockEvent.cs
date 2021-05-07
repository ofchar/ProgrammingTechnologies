using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Data
{
    public class RestockEvent : Event
    {
        public RestockEvent(int id, DateTime timestamp, int amount, int catalogId, int userId)
            : base(id, timestamp, amount, catalogId, userId, true) { }
    }
}
