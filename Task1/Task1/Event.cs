using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Event
    {
        private User user;
        private State state;
        private DateTime purchaseDate;

        public Event(User user, State state, DateTime purchaseDate)
        {
            this.user = user;
            this.state = state;
            this.purchaseDate = purchaseDate;
        }

        public User User { get; set; }

        public State State { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string All { get => user.All + " " + state.All + " " + purchaseDate; }
    }
}
