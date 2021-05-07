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
    public class EventTest
    {
        private void PrepareDatabase()
        {
            UserCRUD userService = new UserCRUD();
            CatalogCRUD catalogService = new CatalogCRUD();

            userService.AddUser(1, "Bleksandra", "Augajska");
            userService.AddUser(2, "Pukasz", "Łorembski");
            userService.AddUser(3, "Sarysia", "Mtasiak");
            userService.AddUser(4, "Zarolina", "Kaborowska");

            catalogService.AddCatalog(1, "Gogh", "Car", 3721, 1237);
            catalogService.AddCatalog(2, "Picasso", "Zielony", 7321, 2137);
            catalogService.AddCatalog(3, "Vivaldi", "Year", 1273, 7321);
            catalogService.AddCatalog(4, "Bethoven", "Ślepy", 7123, 7231);
        }

        private void UnprepareDatabase()
        {
            UserCRUD userService = new UserCRUD();
            CatalogCRUD catalogService = new CatalogCRUD();

            userService.DeleteUser(1);
            userService.DeleteUser(2);
            userService.DeleteUser(3);
            userService.DeleteUser(4);

            catalogService.DeleteCatalog(1);
            catalogService.DeleteCatalog(2);
            catalogService.DeleteCatalog(3);
            catalogService.DeleteCatalog(4);
        }

        [TestMethod]
        public void AddEventTest()
        {
            PrepareDatabase();
            EventCRUD eventService = new EventCRUD();

            Assert.IsTrue(eventService.AddEvent(1, DateTime.Now, true, 6, 1, 2));

            Assert.IsTrue(eventService.DeleteEvent(1));

            UnprepareDatabase();
        }

        [TestMethod]
        public void GetEventTest()
        {
            PrepareDatabase();
            EventCRUD eventService = new EventCRUD();

            eventService.AddEvent(17, DateTime.Now, false, 72, 4, 3);
            Assert.AreEqual(eventService.GetEvent(17).Amount, 72);
            eventService.DeleteEvent(17);

            UnprepareDatabase();
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            PrepareDatabase();
            EventCRUD eventService = new EventCRUD();

            eventService.AddEvent(1, DateTime.Now, false, 10, 1, 1);

            IEnumerable<EventDTO> events = eventService.GetAllEvents();
            Assert.AreEqual(events.Count(), 1);
            Assert.AreEqual(events.ElementAt(0).Id, 1);

            eventService.DeleteEvent(1);
            UnprepareDatabase();
        }
    }
}
