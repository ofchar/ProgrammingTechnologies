using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Services.DTOModels;
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
            CatalogCRUD catalogService = new CatalogCRUD();

            Assert.IsTrue(catalogService.AddCatalog(69, "Monstera", "Monsterowate", 420, 10));

            Assert.IsTrue(catalogService.DeleteCatalog(69));
        }

        [TestMethod]
        public void GetCatalogTest()
        {
            CatalogCRUD catalogService = new CatalogCRUD();

            catalogService.AddCatalog(420, "Friendship is magic", "magic", 123, 321);

            Assert.AreEqual(420, catalogService.GetCatalog(420).Id);

            catalogService.DeleteCatalog(420);
        }

        [TestMethod]
        public void GetAllCatalogsTest()
        {
            CatalogCRUD catalogService = new CatalogCRUD();

            catalogService.AddCatalog(2136, "Rambo", "Bambos", 68, 68);
            catalogService.AddCatalog(2137, "Bambo", "Bambos", 69, 69);
            catalogService.AddCatalog(2138, "Kambo", "Bambos", 70, 70);

            IEnumerable<CatalogDTO> catalogs = catalogService.GetAllCatalogs();

            Assert.AreEqual(catalogs.Count(), 3);

            catalogService.DeleteCatalog(2136);
            catalogService.DeleteCatalog(2137);
            catalogService.DeleteCatalog(2138);
        }

        [TestMethod]
        public void UpdateDonutTest()
        {
            CatalogCRUD catalogService = new CatalogCRUD();

            catalogService.AddCatalog(14, "Walter White", "Cooking", 96, 69);

            Assert.IsTrue(catalogService.UpdateGenus(14, "Meth"));
            Assert.AreEqual(catalogService.GetCatalog(14).Genus, "Meth");

            Assert.IsTrue(catalogService.UpdateName(14, "Jesse Pinkman"));
            Assert.AreEqual(catalogService.GetCatalog(14).Name, "Jesse Pinkman");

            Assert.IsTrue(catalogService.UpdatePrice(14, 420));
            Assert.AreEqual(catalogService.GetCatalog(14).Price, 420);

            Assert.IsTrue(catalogService.UpdateQuantity(14, 2137));
            Assert.AreEqual(catalogService.GetCatalog(14).Quantity, 2137);

            catalogService.DeleteCatalog(14);
        }
    }
}
