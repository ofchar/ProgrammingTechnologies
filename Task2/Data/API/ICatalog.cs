using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface ICatalog
    {
        int Id { get; set; }

        string Name { get; set; }

        string Genus { get; set; }

        int Price { get; set; }

        int Quantity { get; set; }

        string ToString();
    }
}
