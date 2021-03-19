using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class DataService
    {
        private DataRepository repository;

        public DataService(DataRepository repository)
        {
            this.repository = repository;
        }


        #region Display
        public void Display(IEnumerable<User> users)
        {
            foreach(User user in users)
            {
                Console.WriteLine(user.All);
            }
        }
        public void Display(IEnumerable<Catalog> catalogs)
        {
            foreach (Catalog catalog in catalogs)
            {
                Console.WriteLine(catalog.All);
            }
        }
        public void Display(IEnumerable<State> states)
        {
            foreach (State state in states)
            {
                Console.WriteLine(state.All);
            }
        }
        public void Display(IEnumerable<Event> events)
        {
            foreach (Event e in events)
            {
                Console.WriteLine(e.All);
            }
        }
        #endregion

        #region Search
        public List<User> SearchUser(string query)
        {
            List<User> results = new List<User>();

            foreach(User user in repository.GetAllUsers())
            {
                if(user.All.Contains(query))
                {
                    results.Add(user);
                }
            }

            return results;
        }

        public List<Catalog> SearchCatalog(string query)
        {
            List<Catalog> results = new List<Catalog>();

            foreach (Catalog catalog in repository.GetAllCatalogs())
            {
                if (catalog.All.Contains(query))
                {
                    results.Add(catalog);
                }
            }

            return results;
        }

        public List<State> SearchState(string query)
        {
            List<State> results = new List<State>();

            foreach (State state in repository.GetAllStates())
            {
                if (state.All.Contains(query))
                {
                    results.Add(state);
                }
            }

            return results;
        }

        public List<Event> SearchEvent(string query)
        {
            List<Event> results = new List<Event>();

            foreach (Event e in repository.GetAllEvents())
            {
                if (e.All.Contains(query))
                {
                    results.Add(e);
                }
            }

            return results;
        }
        #endregion

        #region Add
        public void AddUser(User user) => repository.AddUser(user);

        public void AddCatalog(Catalog catalog) => repository.AddCatalog(catalog);

        public void AddEvent(Event e) => repository.AddEvent(e);

        public void AddState(State state) => repository.AddState(state);
        #endregion

        #region Create
        public void AddUser(string firstName, string lastName, string uuid) => repository.AddUser(new User(firstName, lastName, uuid));

        public void AddCatalog(string name, string genus, int height) => repository.AddCatalog(new Catalog(name, genus, height));

        public void AddEvent(User user, State state, DateTime purchaseDate) => repository.AddEvent(new Event(user, state, purchaseDate));

        public void AddState(Catalog catalog, int amount, double price) => repository.AddState(new State(catalog, amount, price));
        #endregion

        #region Retrieve relationships
        public List<Event> EventsForUser(User user)
        {
            List<Event> result = new List<Event>();

            foreach(Event e in repository.GetAllEvents())
            {
                if(e.User.Equals(user))
                {
                    result.Add(e);
                }
            }

            return result;
        }

        public List<Event> EventsForState(State state)
        {
            List<Event> result = new List<Event>();

            foreach(Event e in repository.GetAllEvents())
            {
                if(e.State.Equals(state))
                {
                    result.Add(e);
                }
            }

            return result;
        }

        public List<State> StatesForCatalog(Catalog catalog)
        {
            List<State> result = new List<State>();

            foreach(State state in repository.GetAllStates())
            {
                if(state.Catalog.Equals(catalog))
                {
                    result.Add(state);
                }
            }

            return result;
        }
        #endregion
    }
}
