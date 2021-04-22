using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1DataTests
{
    [TestClass]
    public class DataRepositoryTest
    {
        #region utils
        private DataRepository PrepareRepository()
        {
            DataContext context = new DataContext();
            DataRepository repository = new DataRepository(context);

            IDataFill fill = new FillWithConstants();
            fill.Fill(context);

            return repository;
        }
        #endregion



        #region User
        [TestMethod]
        public void AddUser_NewEqualsAdded()
        {
            DataRepository repository = PrepareRepository();

            string newUserUuid = Guid.NewGuid().ToString();

            repository.AddUser("Tonald", "Drump", newUserUuid);

            Assert.AreEqual("Tonald", repository.GetUser(newUserUuid).FirstName);
        }

        [TestMethod]
        public void GetUserTest_CompareWithFillStatic()
        {
            DataRepository repository = PrepareRepository();

            Assert.AreEqual("Lorembski", repository.GetUser("3beea0f3-3bcb-4dfc-a77e-6abe88aadb9b").LastName);
        }

        [TestMethod]
        public void GetAllUsersTest_CompareWithFillStatic()
        {
            DataRepository repository = PrepareRepository();

            List<User> expected = new List<User>();
            expected.Add(new User("Pukasz", "Lorembski", "3beea0f3-3bcb-4dfc-a77e-6abe88aadb9b"));
            expected.Add(new User("Zarolina", "Kaborowska", "c1434771-7e16-4b94-bd69-6a4240a2d728"));
            expected.Add(new User("Kojciech", "Wowner", "e0e49ad8-e7a1-44ee-b1ca-396d34e22eee"));
            expected.Add(new User("Lobert", "Rewandowski", "6c285443-37a0-4347-9e8b-717dd5dfb1e4"));
            expected.Add(new User("Barcin", "M¹k", "19a94215-4477-47c6-93fa-135563c45ee7"));

            List<IUser> tmp = repository.GetAllUsers().ToList<IUser>();

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(tmp[i].ToString(), expected[i].ToString());
            }
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            DataRepository repository = PrepareRepository();

            User user = new User("Test", "Teest", "3beea0f3-3bcb-4dfc-a77e-6abe88aadb9b");

            repository.UpdateUser("3beea0f3-3bcb-4dfc-a77e-6abe88aadb9b", "Test", "Teest");

            Assert.AreEqual(user.ToString(), repository.GetUser("3beea0f3-3bcb-4dfc-a77e-6abe88aadb9b").ToString());
        }

        [TestMethod()]
        public void UpdateUserTest_NoUserToUpdate()
        {
            DataRepository repository = PrepareRepository();

            Assert.ThrowsException<InvalidOperationException>(() => repository.UpdateUser("abcd", "name", "lastName"));
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            DataRepository repository = PrepareRepository();

            string newUserUuid = Guid.NewGuid().ToString();

            repository.AddUser("Tonald", "Drump", newUserUuid);

            Assert.AreEqual("Tonald", repository.GetUser(newUserUuid).FirstName);

            repository.DeleteUser(newUserUuid);

            Assert.ThrowsException<Exception>(() => repository.GetUser(newUserUuid));
        }

        [TestMethod]
        public void DeleteUserTest_NoUserToDelete()
        {
            DataRepository repository = PrepareRepository();

            Assert.ThrowsException<Exception>(() => repository.DeleteUser("0123456789"));
        }

        #endregion


        #region Catalog
        [TestMethod]
        public void AddCatalog_NewEqualsAdded()
        {
            DataRepository repository = PrepareRepository();

            string newCatalogUuid = Guid.NewGuid().ToString();

            ICatalog catalog = new Catalog("Aloe vera", "Aloe", 40, newCatalogUuid);
            repository.AddCatalog("Aloe vera", "Aloe", 40, newCatalogUuid);

            Assert.AreEqual(catalog.ToString(), repository.GetCatalog(newCatalogUuid).ToString());
        }

        [TestMethod]
        public void GetCatalogTest_CompareWithFillStatic()
        {
            DataRepository repository = PrepareRepository();

            Assert.AreEqual("Sansevieria", repository.GetCatalog("2133ae57-1fb3-4f4c-86f5-b1c90beea1a0").Genus);
        }

        [TestMethod]
        public void GetAllCatalogsTest_CompareWithFillStatic()
        {
            DataRepository repository = PrepareRepository();

            List<Catalog> expected = new List<Catalog>();
            expected.Add(new Catalog("Zamioculcas zamiifolia", "Zamioculcas", 40, "6d866448-b7ac-4b03-b5df-e09affd4ec08"));
            expected.Add(new Catalog("Sansevieria trifasciata", "Sansevieria", 30, "2133ae57-1fb3-4f4c-86f5-b1c90beea1a0"));
            expected.Add(new Catalog("Aloe vera", "Aloe", 40, "52c9b0ef-76a2-478c-b8b2-233a416f9f64"));
            expected.Add(new Catalog("Monstera deliciosa", "Monstera", 200, "87c07f4d-d0ee-4202-97b8-b8da14a22eb7"));
            expected.Add(new Catalog("Monstera adansonii ", "Monstera", 150, "47ddc515-2cbd-450a-83e9-0fd1ea223182"));

            List<ICatalog> tmp = repository.GetAllCatalogs().ToList<ICatalog>();

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(tmp[i].ToString(), expected[i].ToString());
            }
        }

        [TestMethod]
        public void UpdateCatalogTest()
        {
            DataRepository repository = PrepareRepository();

            Catalog catalog = new Catalog("Test", "Teest", 12, "87c07f4d-d0ee-4202-97b8-b8da14a22eb7");

            repository.UpdateCatalog("87c07f4d-d0ee-4202-97b8-b8da14a22eb7", "Test", "Teest", 12);

            Assert.AreEqual(catalog.ToString(), repository.GetCatalog("87c07f4d-d0ee-4202-97b8-b8da14a22eb7").ToString());
        }

        [TestMethod]
        public void UpdateCatalogTest_NoCatalogToUpdate()
        {
            DataRepository repository = PrepareRepository();

            Assert.ThrowsException<Exception>(() => repository.UpdateCatalog("1234567890", "test", "genus", 12));
        }

        [TestMethod]
        public void DeleteCatalogTest_CatalogConnectedToState()
        {
            DataRepository repository = PrepareRepository();

            string newCatalogUuid = Guid.NewGuid().ToString();

            repository.AddCatalog("Epipremnum aureum", "epipremnum", 100, newCatalogUuid);

            Assert.AreEqual(100, repository.GetCatalog(newCatalogUuid).Price);

            Assert.ThrowsException<Exception>(() => repository.DeleteCatalog(newCatalogUuid));
        }

        [TestMethod]
        public void DeleteCatalogTest_NoCatalogToDelete()
        {
            DataRepository repository = PrepareRepository();

            Assert.ThrowsException<Exception>(() => repository.DeleteCatalog("0123456789"));
        }
        #endregion


        #region State
        [TestMethod]
        public void GetStateTest_CompareWithFillStatic()
        {
            DataRepository repository = PrepareRepository();

            Assert.AreEqual(3, repository.GetState(1).Amount);
        }

        [TestMethod]
        public void DeleteStateTest()
        {
            DataRepository repository = PrepareRepository();

            repository.AddCatalog("Aloe vera", "Aloe", 40, "asdd");

            Assert.AreEqual(0, repository.GetState(5).Amount);

            IState state = repository.GetCatalogState("asdd");

            repository.DeleteState(state);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => repository.GetState(5));
        }

        [TestMethod]
        public void DeleteStateTest_StateConnectedToEvent()
        {
            DataRepository repository = PrepareRepository();

            IUser user = new User("Testomir", "Testowy", Guid.NewGuid().ToString());
            ICatalog catalog = new Catalog("Aloe vera", "Aloe", 40, "as");

            repository.AddState(catalog, 5);
            repository.AddBuyEvent(user, repository.GetCatalogState("as"), DateTime.Now);

            Assert.AreEqual(5, repository.GetState(5).Amount);

            Assert.ThrowsException<Exception>(() => repository.DeleteState(repository.GetCatalogState("as")));
        }
        #endregion


        #region Event
        [TestMethod]
        public void AddEvent_NewEqualsAdded()
        {
            DataRepository repository = PrepareRepository();

            User user = new User("Testomir", "Testowy", Guid.NewGuid().ToString());
            Catalog catalog = new Catalog("Aloe vera", "Aloe", 40, "asd");

            repository.AddState(catalog, 5);

            repository.AddBuyEvent(user, repository.GetCatalogState("asd"), DateTime.Now); ;

            Assert.AreEqual(user, repository.GetEvent(5).User);
        }

        [TestMethod]
        public void GetEventTest_CompareWithFillStatic()
        {
            DataRepository repository = PrepareRepository();

            Catalog catalog = new Catalog("Zamioculcas zamiifolia", "Zamioculcas", 40, "6d866448-b7ac-4b03-b5df-e09affd4ec08");

            Assert.AreEqual(catalog.ToString(), repository.GetEvent(0).State.Catalog.ToString());
        }

        [TestMethod]
        public void DeleteEventTest()
        {
            DataRepository repository = PrepareRepository();

            State state = new State(new Catalog("Aloe vera", "Aloe", 40, Guid.NewGuid().ToString()), 5);

            repository.AddRestockEvent(new User("Testomir", "Testowy", Guid.NewGuid().ToString()), state, DateTime.Now);

            Assert.AreEqual("Testomir", repository.GetEvent(5).User.FirstName);

            repository.DeleteEvent(repository.GetEvent(5));

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => repository.GetEvent(5));
        }
        #endregion
    }
}
