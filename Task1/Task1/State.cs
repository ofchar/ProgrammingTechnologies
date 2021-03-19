using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class State
    {
        private Catalog catalog; //certain products
        private int amount; //Amount of product in stock
        private double price;
        private DateTime purchaseDate;

        public State(Catalog catalog, int amount, double price, DateTime purchaseDate)
        {
            this.catalog = catalog;
            this.amount = amount;
            this.price = price;
            this.purchaseDate = purchaseDate;
        }

        public Catalog Catalog { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string All { get => catalog.All + " " + amount + " " + price + " " + purchaseDate; }
    }
}
