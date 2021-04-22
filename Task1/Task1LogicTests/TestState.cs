using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Task1LogicTests
{
    internal class TestState : IState
    {
        public ICatalog Catalog { get; set; } //Certain product

        public int Amount { get; set; } //Amount of product in stock

        public TestState(ICatalog catalog, int amount)
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
