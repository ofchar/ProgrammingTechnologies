using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class State
    {
        public Catalog Catalog { get; set; } //Certain product

        public int Amount { get; set; } //Amount of product in stock

        public double Price { get; set; }

        public DateTime PurchaseDate { get; set; }


        public State(Catalog catalog, int amount, double price, DateTime purchaseDate)
        {
            Catalog = catalog;
            Amount = amount;
            Price = price;
            PurchaseDate = purchaseDate;
        }


        public override string ToString() 
        { 
            return Catalog.ToString() + " " + Amount + " " + Price + " " + PurchaseDate; 
        }
    }
}
