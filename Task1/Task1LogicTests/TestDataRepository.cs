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
        private List<User> users;
        private List<Catalog> catalogs;
        private List<Event> events;
        private List<State> states;

        public TestDataRepository()
        {
            users = new List<User>();
            catalogs = new List<Catalog>();
            events = new List<Event>();
            states = new List<State>();
        }



        #region User
        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User GetUser(string uuid)
        {
            return new User("FirstName", "LastName", uuid);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public void UpdateUser(string uuid, User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string uuid)
        {
            User temp = users.First(u => u.Uuid == uuid);

            users.Remove(temp);
        }
        #endregion


        #region Catalog
        public void AddCatalog(Catalog catalog)
        {
            catalogs.Add(catalog);
        }

        public Catalog GetCatalog(string uuid)
        {
            return new Catalog("name", "genus", 15, uuid);
        }

        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return catalogs;
        }

        public void UpdateCatalog(string uuid, Catalog catalog)
        {
            throw new NotImplementedException();
        }

        public void DeleteCatalog(string uuid)
        {
            Catalog catalog = catalogs.First(c => c.Uuid == uuid);

            catalogs.Remove(catalog);
        }
        #endregion


        #region Event
        public void AddEvent(Event e)
        {
            events.Add(e);
        }

        public Event GetEvent(int position)
        {
            User user = new User("name", "lastName", "niceUuid");

            Catalog catalog = new Catalog("name", "genus", 2, "catalogsUuid");
            State state = new State(catalog, 11);

            return new BuyEvent(user, state, new DateTime(2021, 01, 01));
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return events;
        }

        public void DeleteEvent(Event e)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent(int position)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region State
        public void AddState(State state)
        {
            states.Add(state);
        }

        public State GetState(int position)
        {
            Catalog catalog = new Catalog("name", "genus", 2, "catalogsUuid");

            return new State(catalog, 10);
        }

        public State GetCatalogState(string catalogUuid)
        {
            return states.Last(state => state.Catalog.Uuid == catalogUuid);
        }

        public IEnumerable<State> GetAllStates()
        {
            return states;
        }

        public void UpdateState(string catalogUuid, int newAmount)
        {
            State temp = states.FindLast(state => state.Catalog.Uuid == catalogUuid);

            temp.Amount = newAmount;
        }

        public void DeleteState(State state)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
