using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTest
{
    public class TestCatalog : ICatalog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genus { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }



        public TestCatalog(int id, string name, string genus, int quatity, int price)
        {
            Id = id;
            Name = name;
            Genus = genus;
            Quantity = quatity;
            Price = price;
        }

        public override string ToString()
        {
            return Id + " " + Name + " " + Genus + " " + Quantity + " " + Price;
        }
    }
}
