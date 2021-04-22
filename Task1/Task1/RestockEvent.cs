using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RestockEvent : Event
    {
        public RestockEvent(IUser user, IState state, DateTime timestamp)
            : base(user, state, timestamp) { }
    }
}
