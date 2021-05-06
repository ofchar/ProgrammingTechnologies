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
            UserCRUD.AddUser(1, "Bleksandra", "Augajska");
            UserCRUD.AddUser(2, "Pukasz", "Łorembski");
            UserCRUD.AddUser(3, "Sarysia", "Mtasiak");
            UserCRUD.AddUser(4, "Zarolina", "Kaborowska");

            CatalogCRUD.AddCatalog(1, "Gogh", "Car", 3721, 1237);
            CatalogCRUD.AddCatalog(2, "Picasso", "Zielony", 7321, 2137);
            CatalogCRUD.AddCatalog(3, "Vivaldi", "Year", 1273, 7321);
            CatalogCRUD.AddCatalog(4, "Bethoven", "Ślepy", 7123, 7231);
        }

        private void UnprepareDatabase()
        {
            UserCRUD.DeleteUser(1);
            UserCRUD.DeleteUser(2);
            UserCRUD.DeleteUser(3);
            UserCRUD.DeleteUser(4);

            CatalogCRUD.DeleteCatalog(1);
            CatalogCRUD.DeleteCatalog(2);
            CatalogCRUD.DeleteCatalog(3);
            CatalogCRUD.DeleteCatalog(4);
        }

        [TestMethod]
        public void AddEventTest()
        {
            PrepareDatabase();

            Assert.IsTrue(EventCRUD.AddEvent(1, DateTime.Now, true, 6, 1, 2));

            Assert.IsTrue(EventCRUD.DeleteEvent(1));

            UnprepareDatabase();
        }

        [TestMethod]
        public void GetEventTest()
        {
            PrepareDatabase();

            EventCRUD.AddEvent(17, DateTime.Now, false, 72, 4, 3);
            Assert.AreEqual(EventCRUD.GetEvent(17).Amount, 72);
            EventCRUD.DeleteEvent(17);

            UnprepareDatabase();
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            PrepareDatabase();
            EventCRUD.AddEvent(1, DateTime.Now, false, 10, 1, 1);

            IEnumerable<EventDTO> events = EventCRUD.GetAllEvents();
            Assert.AreEqual(events.Count(), 1);
            Assert.AreEqual(events.ElementAt(0).Id, 1);

            EventCRUD.DeleteEvent(1);
            UnprepareDatabase();
        }

        [TestMethod]
        public void GetEventsByUserTest()
        {
            PrepareDatabase();
            EventCRUD.AddEvent(1, DateTime.Now, false, 10, 1, 1);
            EventCRUD.AddEvent(2, DateTime.Now, true, 15, 2, 1);
            EventCRUD.AddEvent(3, DateTime.Now, false, 20, 3, 2);

            IEnumerable<EventDTO> events = EventCRUD.GetEventsByUser(1);
            Assert.AreEqual(events.Count(), 2);
            Assert.AreEqual(events.ElementAt(0).Id, 1);

            EventCRUD.DeleteEvent(1);
            EventCRUD.DeleteEvent(2);
            EventCRUD.DeleteEvent(3);
            UnprepareDatabase();
        }

        [TestMethod]
        public void GetEventsByCatalogTest()
        {
            PrepareDatabase();
            EventCRUD.AddEvent(1, DateTime.Now, false, 10, 1, 1);
            EventCRUD.AddEvent(2, DateTime.Now, true, 15, 2, 1);
            EventCRUD.AddEvent(3, DateTime.Now, false, 20, 2, 2);

            IEnumerable<EventDTO> events = EventCRUD.GetEventsByCatalog(2);
            Assert.AreEqual(events.Count(), 2);
            Assert.AreEqual(events.ElementAt(0).Id, 2);

            EventCRUD.DeleteEvent(1);
            EventCRUD.DeleteEvent(2);
            EventCRUD.DeleteEvent(3);
            UnprepareDatabase();
        }

        [TestMethod]
        public void GetEventsByTypeTest()
        {
            PrepareDatabase();
            EventCRUD.AddEvent(1, DateTime.Now, false, 10, 1, 1);
            EventCRUD.AddEvent(2, DateTime.Now, true, 15, 2, 1);
            EventCRUD.AddEvent(3, DateTime.Now, true, 20, 3, 2);

            IEnumerable<EventDTO> events = EventCRUD.GetEventsByType(true);
            Assert.AreEqual(events.Count(), 2);
            Assert.AreEqual(events.ElementAt(0).Id, 2);

            EventCRUD.DeleteEvent(1);
            EventCRUD.DeleteEvent(2);
            EventCRUD.DeleteEvent(3);
            UnprepareDatabase();
        }

        [TestMethod]
        public void GetEventsByUserNamesTest()
        {
            PrepareDatabase();
            EventCRUD.AddEvent(1, DateTime.Now, false, 10, 1, 1);
            EventCRUD.AddEvent(2, DateTime.Now, true, 15, 2, 1);
            EventCRUD.AddEvent(3, DateTime.Now, false, 20, 3, 2);

            IEnumerable<EventDTO> events = EventCRUD.GetEventsByUserNames("Bleksandra", "Augajska");
            Assert.AreEqual(events.Count(), 2);
            Assert.AreEqual(events.ElementAt(0).Id, 1);

            EventCRUD.DeleteEvent(1);
            EventCRUD.DeleteEvent(2);
            EventCRUD.DeleteEvent(3);
            UnprepareDatabase();
        }
    }
}
