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
    public class DataServicesTest
    {
        [TestMethod]
        public void AddUserTest()
        {
            UserCRUD userService = new UserCRUD(new TestDataRepository());

            Assert.IsTrue(userService.AddUser(67, "Jan", "Paweł the second"));
            Assert.IsTrue(userService.DeleteUser(67));
        }

        [TestMethod]
        public void GetUserTest()
        {
            UserCRUD userService = new UserCRUD(new TestDataRepository());

            userService.AddUser(88, "Chloe", "Price");

            Assert.AreEqual(userService.GetUser(88).FirstName, "Chloe");

            userService.DeleteUser(88);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            UserCRUD userService = new UserCRUD(new TestDataRepository());

            userService.AddUser(11, "Max", "Verstappen");

            Assert.IsTrue(userService.UpdateLastName(11, "Caulfield"));
            Assert.AreEqual(userService.GetUser(11).LastName, "Caulfield");

            Assert.IsTrue(userService.UpdateFirstName(11, "Timothy"));
            Assert.AreEqual(userService.GetUser(11).FirstName, "Timothy");

            userService.DeleteUser(11);
        }

        [TestMethod]
        public void GetUsersTest()
        {
            UserCRUD userService = new UserCRUD(new TestDataRepository());

            userService.AddUser(16, "Wartłomiej", "Błodarski");
            userService.AddUser(19, "Kaciej", "Mopa");
            userService.AddUser(22, "Wartłomiej", "Bubicki");

            IEnumerable<UserDTO> users = userService.GetAllUsers();

            Assert.AreEqual(users.Count(), 3);

            userService.DeleteUser(16);
            userService.DeleteUser(19);
            userService.DeleteUser(22);
        }






        [TestMethod]
        public void AddCatalogTest()
        {
            CatalogCRUD catalogService = new CatalogCRUD(new TestDataRepository());

            Assert.IsTrue(catalogService.AddCatalog(69, "Monstera", "Monsterowate", 420, 10));

            Assert.IsTrue(catalogService.DeleteCatalog(69));
        }

        [TestMethod]
        public void GetCatalogTest()
        {
            CatalogCRUD catalogService = new CatalogCRUD(new TestDataRepository());

            catalogService.AddCatalog(420, "Friendship is magic", "magic", 123, 321);

            Assert.AreEqual(420, catalogService.GetCatalog(420).Id);

            catalogService.DeleteCatalog(420);
        }

        [TestMethod]
        public void GetAllCatalogsTest()
        {
            CatalogCRUD catalogService = new CatalogCRUD(new TestDataRepository());

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
            CatalogCRUD catalogService = new CatalogCRUD(new TestDataRepository());

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







        [TestMethod]
        public void AddEventTest()
        {
            EventCRUD eventService = new EventCRUD(new TestDataRepository());

            Assert.IsTrue(eventService.AddEvent(1, DateTime.Now, true, 6, 1, 2));

            Assert.IsTrue(eventService.DeleteEvent(1));
        }

        [TestMethod]
        public void GetEventTest()
        {
            EventCRUD eventService = new EventCRUD(new TestDataRepository());

            eventService.AddEvent(17, DateTime.Now, false, 72, 4, 3);
            Assert.AreEqual(eventService.GetEvent(17).Amount, 72);
            eventService.DeleteEvent(17);
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            EventCRUD eventService = new EventCRUD(new TestDataRepository());

            eventService.AddEvent(1, DateTime.Now, false, 10, 1, 1);

            IEnumerable<EventDTO> events = eventService.GetAllEvents();
            Assert.AreEqual(events.Count(), 1);
            Assert.AreEqual(events.ElementAt(0).Id, 1);

            eventService.DeleteEvent(1);
        }
    }
}
