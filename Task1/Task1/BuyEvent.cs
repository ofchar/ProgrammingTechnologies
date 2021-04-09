using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BuyEvent : Event
    {
        public BuyEvent(User user, State state, DateTime timestamp)
            : base(user, state, timestamp) { }
    }
}
