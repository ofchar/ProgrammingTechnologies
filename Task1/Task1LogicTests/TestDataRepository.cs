using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1LogicTests
{
    public class TestDataRepository : IDataApi
    {
        private List<IUser> users;
        private List<ICatalog> catalogs;
        private List<IEvent> events;
        private List<IState> states;

        public TestDataRepository()
        {
            users = new List<IUser>();
            catalogs = new List<ICatalog>();
            events = new List<IEvent>();
            states = new List<IState>();
        }



        #region User
        public void AddUser(string firstName, string lastName, string uuid)
        {
            users.Add(new TestUser(firstName, lastName, uuid));
        }

        public void AddUser(string firstName, string lastName)
        {
            users.Add(new TestUser(firstName, lastName, Guid.NewGuid().ToString()));
        }

        public IUser GetUser(string uuid)
        {
            return new TestUser("FirstName", "LastName", uuid);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return users;
        }

        public void UpdateUser(string uuid, string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string uuid)
        {
            TestUser temp = (TestUser)users.First(u => u.Uuid == uuid);

            users.Remove(temp);
        }
        #endregion


        #region Catalog
        public void AddCatalog(string name, string genus, double price, string uuid)
        {
            TestCatalog catalog = new TestCatalog(name, genus, price, uuid);

            catalogs.Add(catalog);

            states.Add(new TestState(catalog, 0));
        }

        public void AddCatalog(string name, string genus, double price)
        {
            TestCatalog catalog = new TestCatalog(name, genus, price, Guid.NewGuid().ToString());

            catalogs.Add(catalog);

            states.Add(new TestState(catalog, 0));
        }

        public ICatalog GetCatalog(string uuid)
        {
            return new TestCatalog("name", "genus", 15, uuid);
        }

        public IEnumerable<ICatalog> GetAllCatalogs()
        {
            return catalogs;
        }

        public void UpdateCatalog(string uuid, string name, string genus, double price)
        {
            throw new NotImplementedException();
        }

        public void DeleteCatalog(string uuid)
        {
            TestCatalog catalog = (TestCatalog)catalogs.First(c => c.Uuid == uuid);

            catalogs.Remove(catalog);
        }
        #endregion


        #region Event
        public void AddBuyEvent(IUser user, IState state, DateTime timestamp)
        {
            events.Add(new TestBuyEvent(user, state, timestamp));
        }

        public void AddRestockEvent(IUser user, IState state, DateTime timestamp)
        {
            events.Add(new TestBuyEvent(user, state, timestamp));
        }

        public IEvent GetEvent(int position)
        {
            TestUser user = new TestUser("name", "lastName", "niceUuid");

            TestCatalog catalog = new TestCatalog("name", "genus", 2, "catalogsUuid");
            TestState state = new TestState(catalog, 11);

            return new TestBuyEvent(user, state, new DateTime(2021, 01, 01));
        }

        public IEnumerable<IEvent> GetAllEvents()
        {
            return events;
        }

        public void DeleteEvent(IEvent e)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent(int position)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region State
        public void AddState(ICatalog catalog, int amount)
        {
            states.Add(new TestState(catalog, amount));
        }

        public IState GetState(int position)
        {
            TestCatalog catalog = new TestCatalog("name", "genus", 2, "catalogsUuid");

            return new TestState(catalog, 10);
        }

        public IState GetCatalogState(string catalogUuid)
        {
            return states.Last(state => state.Catalog.Uuid == catalogUuid);
        }

        public IEnumerable<IState> GetAllStates()
        {
            return states;
        }

        public void UpdateState(string catalogUuid, int newAmount)
        {
            TestState temp = (TestState)states.FindLast(state => state.Catalog.Uuid == catalogUuid);

            temp.Amount = newAmount;
        }

        public void DeleteState(IState state)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
