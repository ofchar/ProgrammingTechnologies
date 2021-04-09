using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Catalog
    {
        public string Name { get; set; }

        public string Genus { get; set; }

        public double Price { get; set; }

        public string Uuid { get; set; }


        public Catalog(string name, string genus, double price, string uuid)
        {
            Name = name;
            Genus = genus;
            Price = price;
            Uuid = uuid;
        }


        public override string ToString() 
        { 
            return Name + " " + Genus + " " + Price + " " + Uuid;
        }
    }
}
