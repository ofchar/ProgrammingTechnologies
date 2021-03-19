using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Catalog
    {
        private string name;
        private string genus;
        private int height;

        public Catalog(string name, string genus, int height)
        {
            this.name = name;
            this.genus = genus;
            this.height = height;
        }

        public string Name { get; set; }

        public string Genus { get; set; }

        public int Height { get; set; }

        public string All { get => name + " " + genus + " " + height; }
    }
}
