using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Event : IEvent
    {
        public IUser User { get; set; }

        public IState State { get; set; }

        public DateTime Timestamp { get; set; }


        public Event(IUser user, IState state, DateTime timestamp)
        {
            User = user;
            State = state;
            Timestamp = timestamp;
        }


        public override string ToString() 
        { 
            return User.ToString() + " " + State.ToString() + " " + Timestamp; 
        }
    }
}
