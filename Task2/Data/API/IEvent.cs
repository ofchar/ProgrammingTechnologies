using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IEvent
    {
        int Id { get; set; }

        DateTime Timestamp { get; set; }

        int Amount { get; set; }

        int CatalogId { get; set; }

        int UserId { get; set; }

        bool IsRestock { get; set; }


        string ToString();
    }
}
