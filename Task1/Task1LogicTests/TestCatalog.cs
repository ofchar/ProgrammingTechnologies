using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Task1LogicTests
{
    internal class TestCatalog : ICatalog
    {
        public string Name { get; set; }

        public string Genus { get; set; }

        public double Price { get; set; }

        public string Uuid { get; set; }


        public TestCatalog(string name, string genus, double price, string uuid)
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
