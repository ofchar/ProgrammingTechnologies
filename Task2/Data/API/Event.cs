using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public abstract class Event : IEvent
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public int Amount { get; set; }

        public int CatalogId { get; set; }

        public int UserId { get; set; }

        public bool IsRestock { get; set; }

        
        public Event(int id, DateTime timestamp, int amount, int catalogId, int userId, bool restock)
        {
            Id = id;
            Timestamp = timestamp;
            Amount = amount;
            CatalogId = catalogId;
            UserId = userId;
            IsRestock = restock;
        }

        public override string ToString()
        {
            return Id + " " + Timestamp + " " + Amount + " " + CatalogId + " " + UserId;
        }
    }
}
