using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
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

        }

        public void DeleteUser(string uuid)
        {

        }
        public void DeleteUser(User user)
        {

        }
        #endregion


        #region Catalog
        public void AddCatalog(Catalog catalog)
        {
            catalogs.Add(catalog);
        }

        public Catalog GetCatalog(int pos)
        {
            return new Catalog("name", "genus", 10, "someUuid");
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

        }

        public void DeleteCatalog(Catalog catalog)
        {

        }

        public void DeleteCatalog(string uuid)
        {

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
            State state = new State(catalog, 11, 25);

            return new Event(user, state, new DateTime(2021, 01, 01));
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return events;
        }

        public void DeleteEvent(Event e)
        {

        }

        public void DeleteEvent(int position)
        {

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

            return new State(catalog, 10, 20);
        }

        public State GetCurrentCatalogState(Catalog catalog)
        {
            return new State(catalog, 10, 20);
        }

        public IEnumerable<State> GetAllStates()
        {
            return states;
        }

        public void DeleteState(State state)
        {

        }

        public void DeleteState(int position)
        {

        }
        #endregion
    }
}
