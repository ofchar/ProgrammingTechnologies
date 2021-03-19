using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class State
    {
        private Catalog catalog;
        private int amount;
        private double price;

        public State(Catalog catalog, int amount, double price)
        {
            this.catalog = catalog;
            this.amount = amount;
            this.price = price;
        }

        public Catalog Catalog { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public string All { get => catalog.All + " " + amount + " " + price; }
    }
}
