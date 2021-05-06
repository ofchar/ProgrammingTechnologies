using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOModels
{
    public class EventDTO
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsStocking { get; set; }

        public int Amount { get; set; }

        public int Catalog_id { get; set; }

        public int User_id { get; set; }
    }
}
