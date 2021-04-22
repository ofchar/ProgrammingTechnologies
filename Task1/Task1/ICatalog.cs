using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ICatalog
    {
        string Name { get; set; }

        string Genus { get; set; }

        double Price { get; set; }

        string Uuid { get; set; }

        string ToString();
    }
}
