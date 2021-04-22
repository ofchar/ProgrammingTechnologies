using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Logic;
using Data;

namespace Task1LogicTests
{
    [TestClass]
    public class DataServiceTest
    {
        #region utils
        private DataService createDataService()
        {
            return new DataService(new TestDataRepository());
        }
        #endregion



        #region Relations tests
        private void fillCatalogs(DataService service)
        {
            service.CreateCatalog("name1", "genus1", 10, "catalogUuid1");
            service.CreateCatalog("name2", "genus2", 20, "catalogUuid2");
            service.CreateCatalog("name3", "genus3", 30, "catalogUuid3");
        }

        private void fillEvents(DataService service)
        {
            service.Restock("userUuid1", "catalogUuid1", new DateTime(2021, 04, 04), 5);
            service.Restock("userUuid1", "catalogUuid2", new DateTime(2021, 03, 03), 10);
            service.Restock("userUuid2", "catalogUuid2", new DateTime(2021, 02, 02), 20);
        }


        [TestMethod()]
        public void EventsForUserTest()
        {
            DataService service = createDataService();

            fillCatalogs(service);
            fillEvents(service);

            List<IEvent> events = service.EventsForUser("userUuid1");

            Assert.AreEqual(2, events.Count);

            Assert.AreEqual("userUuid1", events[0].User.Uuid);
            Assert.AreEqual("userUuid1", events[1].User.Uuid);
        }

        [TestMethod()]
        public void EventsForCatalogTest()
        {
            DataService service = createDataService();

            fillCatalogs(service);
            fillEvents(service);

            List<IEvent> events = service.EventsForCatalog("catalogUuid2");

            Assert.AreEqual(2, events.Count);

            Assert.AreEqual("catalogUuid2", events[0].State.Catalog.Uuid);
            Assert.AreEqual("catalogUuid2", events[1].State.Catalog.Uuid);
        }

        [TestMethod()]
        public void CurrentCatalogStateTest()
        {
            DataService service = createDataService();

            fillCatalogs(service);

            IState state = service.CurrentCatalogState("catalogUuid3");

            Assert.AreEqual("catalogUuid3", state.Catalog.Uuid);
        }
        #endregion


        #region Actions tests
        [TestMethod()]
        public void RestockTest()
        {
            DataService service = createDataService();

            string productUuid = "someTestUuid";
            service.CreateCatalog("flower1", "flowerGenus1", 10, productUuid);

            service.Restock("SomeUuid", productUuid, DateTime.Now, 9);

            IState state = service.CurrentCatalogState(productUuid);
            Assert.AreEqual(9, state.Amount);
        }

        [TestMethod()]
        public void BuyTest_thereIsEnoughProductInStock()
        {
            DataService service = createDataService();

            string productUuid = "someTestUuid";
            service.CreateCatalog("flower1", "flowerGenus1", 10, productUuid);
            
            service.Restock("SomeUuid", productUuid, DateTime.Now, 9);

            service.Buy("SomeUuid", productUuid, DateTime.Now, 1);

            List<IEvent> events = service.SearchEvent(productUuid);

            Assert.AreEqual(8, events[0].State.Amount);
        }

        [TestMethod()]
        public void BuyTest_thereIsNotEnoughProductInStock()
        {
            DataService service = createDataService();

            string productUuid = "someTestUuid";
            service.CreateCatalog("flower1", "flowerGenus1", 10, productUuid);

            Assert.ThrowsException<Exception>(() => service.Buy("SomeUuid", productUuid, DateTime.Now, 9));
        }
        #endregion


        #region Search methods tests
        [TestMethod()]
        public void UserSearch()
        {
            DataService service = createDataService();

            service.CreateUser("Monika", "Jaworowicz");
            service.CreateUser("Marcel", "Dyndala");

            List<IUser> users = service.SearchUser("Monika");

            Assert.AreEqual(1, users.Count);
            Assert.AreEqual("Monika", users[0].FirstName);
        }

        [TestMethod()]
        public void CatalogSearch()
        {
            DataService service = createDataService();

            service.CreateCatalog("roslina1", "gatunek1", 10);
            service.CreateCatalog("flower2", "genus2", 33);

            List<ICatalog> catalogs = service.SearchCatalog("genus2");

            Assert.AreEqual(1, catalogs.Count);
            Assert.AreEqual("flower2", catalogs[0].Name);
        }

        [TestMethod()]
        public void StateSearch()
        {
            DataService service = createDataService();

            service.CreateCatalog("name1", "genus1", 10, "uuid1");
            service.CreateCatalog("name2", "genus2", 20, "uuid2");

            List<IState> states = service.SearchState("genus2");

            Assert.AreEqual(1, states.Count);
            Assert.AreEqual(0, states[0].Amount);
        }

        [TestMethod()]
        public void EventSearch()
        {
            DataService service = createDataService();

            string productUuid = "someTestUuid";
            service.CreateCatalog("flower1", "flowerGenus1", 10, productUuid);

            service.Restock("SomeUuid", productUuid, DateTime.Now, 9);

            List<IEvent> events = service.SearchEvent("flower1");

            Assert.AreEqual(1, events.Count);
            Assert.AreEqual(9, events[0].State.Amount);
        }
        #endregion


        #region Service's Crud tests
        [TestMethod()]
        public void UserCRUDTest()
        {
            DataService service = createDataService();

            //getUser returns always the same user, because of test version of DataRepository.
            Assert.AreEqual("FirstName", service.GetUser("someGoodUuid").FirstName);


            service.CreateUser("Adam", "Tester", "someGoodUuid1");
            service.CreateUser("Adam", "Tester");

            List<IUser> users = (List<IUser>)service.GetAllUsers();
            Assert.AreEqual(2, users.Count);


            service.DeleteUser("someGoodUuid1");

            users = (List<IUser>)service.GetAllUsers();
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod()]
        public void CatalogCRUDTest()
        {
            DataService service = createDataService();

            //getCatalog returns always the same catalog, because of test version of DataRepository.
            Assert.AreEqual("genus", service.GetCatalog("someGoodUuid").Genus);


            service.CreateCatalog("flower", "flowerrs", 50, "niceUuid");
            service.CreateCatalog("otherFlower", "otherFlowerrs", 100);

            List<ICatalog> catalogs = (List<ICatalog>)service.GetAllCatalogs();
            Assert.AreEqual(2, catalogs.Count);


            service.DeleteCatalog("niceUuid");

            catalogs = (List<ICatalog>)service.GetAllCatalogs();
            Assert.AreEqual(1, catalogs.Count);
        }
        #endregion
    }
}
