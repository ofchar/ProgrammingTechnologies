using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class State
    {
        public Catalog Catalog { get; set; } //Certain product

        public int Amount { get; set; } //Amount of product in stock

        public State(Catalog catalog, int amount)
        {
            Catalog = catalog;
            Amount = amount;
        }


        public override string ToString() 
        {
            return Catalog.ToString() + " " + Amount;
        }
    }
}
