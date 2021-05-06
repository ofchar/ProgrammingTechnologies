﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOModels
{
    public class CatalogDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genus { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }
    }
}
