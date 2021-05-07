using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Data
{
    public class BuyEvent : Event
    {
        public BuyEvent(int id, DateTime timestamp, int amount, int catalogId, int userId)
            : base(id, timestamp, amount, catalogId, userId, false) { }
    }
}
