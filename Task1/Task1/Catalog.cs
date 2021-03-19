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
        private string uuid;

        public Catalog(string name, string genus, int height, string uuid)
        {
            this.name = name;
            this.genus = genus;
            this.height = height;
            this.uuid = uuid;
        }

        public string Name { get; set; }

        public string Genus { get; set; }

        public int Height { get; set; }

        public string Uuid { get; set; }

        public string All { get => name + " " + genus + " " + height + " " + uuid; }
    }
}
