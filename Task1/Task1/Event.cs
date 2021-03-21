using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Event
    {
        public User User { get; set; }

        public State State { get; set; }

        public DateTime PurchaseDate { get; set; }


        public Event(User user, State state, DateTime purchaseDate)
        {
            User = user;
            State = state;
            PurchaseDate = purchaseDate;
        }


        public override string ToString() 
        { 
            return User.ToString() + " " + State.ToString() + " " + PurchaseDate; 
        }
    }
}
