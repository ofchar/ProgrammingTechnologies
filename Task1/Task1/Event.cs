using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class Event
    {
        public User User { get; set; }

        public State State { get; set; }

        public DateTime Timestamp { get; set; }


        public Event(User user, State state, DateTime timestamp)
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
