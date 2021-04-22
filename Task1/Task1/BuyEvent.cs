using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BuyEvent : Event
    {
        public BuyEvent(IUser user, IState state, DateTime timestamp)
            : base(user, state, timestamp) { }
    }
}
