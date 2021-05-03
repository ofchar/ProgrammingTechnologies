﻿using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesTest
{
    [TestClass]
    public class CatalogTest
    {
        [TestMethod]
        public void AddCatalogTest()
        {
            Assert.IsTrue(CatalogCRUD.AddCatalog(69, "Monstera", "Monsterowate", 420, 10));

            Assert.IsTrue(CatalogCRUD.DeleteCatalog(69));
        }

        [TestMethod]
        public void GetCatalogTest()
        {
            CatalogCRUD.AddCatalog(420, "Friendship is magic", "magic", 123, 321);

            Assert.AreEqual(420, CatalogCRUD.GetCatalog(420).catalog_id);
            Assert.AreEqual(321, CatalogCRUD.GetCatalogByName("Friendship is magic").catalog_quantity);

            CatalogCRUD.DeleteCatalog(420);
        }

        [TestMethod]
        public void GetCatalogsTest()
        {
            CatalogCRUD.AddCatalog(2136, "Rainbow Dash", "Friendship", 68, 68);
            CatalogCRUD.AddCatalog(2137, "Fluttershy", "Friendship", 69, 69);
            CatalogCRUD.AddCatalog(2138, "Apple Jack", "Friendship", 70, 70);

            IEnumerable<catalog> catalogs = CatalogCRUD.GetCatalogsByGenus("Friendship");
            Assert.AreEqual(catalogs.Count(), 3);
            Assert.AreEqual(catalogs.ElementAt(0).catalog_name, "Rainbow Dash");
            Assert.AreEqual(catalogs.ElementAt(1).catalog_id, 2137);
            Assert.AreEqual(catalogs.ElementAt(2).catalog_price, 70);

            CatalogCRUD.DeleteCatalog(2136);
            CatalogCRUD.DeleteCatalog(2137);
            CatalogCRUD.DeleteCatalog(2138);
        }

        [TestMethod]
        public void GetAllCatalogsTest()
        {
            CatalogCRUD.AddCatalog(2136, "Rambo", "Bambos", 68, 68);
            CatalogCRUD.AddCatalog(2137, "Bambo", "Bambos", 69, 69);
            CatalogCRUD.AddCatalog(2138, "Kambo", "Bambos", 70, 70);

            IEnumerable<catalog> catalogs = CatalogCRUD.GetAllCatalogs();

            Assert.AreEqual(catalogs.Count(), 3);

            CatalogCRUD.DeleteCatalog(2136);
            CatalogCRUD.DeleteCatalog(2137);
            CatalogCRUD.DeleteCatalog(2138);
        }

        [TestMethod]
        public void UpdateDonutTest()
        {
            CatalogCRUD.AddCatalog(14, "Walter White", "Cooking", 96, 69);

            Assert.IsTrue(CatalogCRUD.UpdateGenus(14, "Meth"));
            Assert.AreEqual(CatalogCRUD.GetCatalog(14).catalog_genus, "Meth");

            Assert.IsTrue(CatalogCRUD.UpdateName(14, "Jesse Pinkman"));
            Assert.AreEqual(CatalogCRUD.GetCatalog(14).catalog_name, "Jesse Pinkman");

            Assert.IsTrue(CatalogCRUD.UpdatePrice(14, 420));
            Assert.AreEqual(CatalogCRUD.GetCatalog(14).catalog_price, 420);

            Assert.IsTrue(CatalogCRUD.UpdateQuantity(14, 2137));
            Assert.AreEqual(CatalogCRUD.GetCatalog(14).catalog_quantity, 2137);

            CatalogCRUD.DeleteCatalog(14);
        }
    }
}
