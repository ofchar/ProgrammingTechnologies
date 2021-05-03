using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Data;
using System.Data.SqlClient;


namespace DataTest
{
    [TestClass]
    public class DataTest
    {
        private string sqlString = "Data Source = DESKTOP-2JETCTM; Initial Catalog = ptdb; Integrated Security = True";

        [TestMethod]
        public void AddFlowerToDatabase()
        {
            using (DataClasses1DataContext database = new DataClasses1DataContext(sqlString))
            {
                catalog catalog = new catalog();
                catalog.catalog_id = 2;
                catalog.catalog_name = "a nice flower";
                catalog.catalog_genus = "with nice genus";
                catalog.catalog_price = 80;
                catalog.catalog_quantity = 0;

                database.catalogs.InsertOnSubmit(catalog);
                database.SubmitChanges();

                catalog cat = database.catalogs.FirstOrDefault(cats => cats.catalog_id.Equals(2));
                Assert.AreEqual(cat.catalog_id, 2);
                Assert.AreEqual(cat.catalog_name, "a nice flower");
                Assert.AreEqual(cat.catalog_genus, "with nice genus");
                Assert.AreEqual(cat.catalog_price, 80);
                Assert.AreEqual(cat.catalog_quantity, 0);

                database.catalogs.DeleteOnSubmit(catalog);
                database.SubmitChanges();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(System.Data.SqlClient.SqlException))]
        public void ConnectingToNonExsistingDB()
        {
            using (DataClasses1DataContext fake = new DataClasses1DataContext("Data Source = DESKTOP-2JETCTM; Initial Catalog = upssNothingHere; Integrated Security = True"))
            {
                catalog catalog = new catalog();
                catalog.catalog_id = 2;
                catalog.catalog_name = "a nice flower";
                catalog.catalog_genus = "with nice genus";
                catalog.catalog_price = 80;
                catalog.catalog_quantity = 0;

                fake.catalogs.InsertOnSubmit(catalog);
                fake.SubmitChanges();
            }
        }
    }
}
