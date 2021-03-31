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
                Console.WriteLine(user.ToString());
            }
        }
        public void Display(IEnumerable<Catalog> catalogs)
        {
            foreach (Catalog catalog in catalogs)
            {
                Console.WriteLine(catalog.ToString());
            }
        }
        public void Display(IEnumerable<State> states)
        {
            foreach (State state in states)
            {
                Console.WriteLine(state.ToString());
            }
        }
        public void Display(IEnumerable<Event> events)
        {
            foreach (Event e in events)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region Get
        
        #region User
        public User GetUser(string uuid)
        {
            return repository.GetUser(uuid);
        }

        public List<User> GetAllUsers()
        {
            return (List<User>)repository.GetAllUsers();
        }
        #endregion

        #region Catalog
        public Catalog GetCatalog(string uuid)
        {
            return repository.GetCatalog(uuid);
        }

        public List<Catalog> GetAllCatalogs()
        {
            return (List<Catalog>)repository.GetAllCatalogs();
        }
        #endregion

        #region State
        public State GetState(int position)
        {
            return repository.GetState(position);
        }

        public List<State> GetAllStates()
        {
            return (List<State>)repository.GetAllStates();
        }
        #endregion

        #region Event
        public Event GetEvent(int position)
        {
            return repository.GetEvent(position);
        }

        public List<Event> GetAllEvents()
        {
            return (List<Event>)repository.GetAllEvents();
        }
        #endregion

        #endregion

        #region Search
        public List<User> SearchUser(string query)
        {
            List<User> results = new List<User>();

            foreach(User user in repository.GetAllUsers())
            {
                if(user.ToString().Contains(query))
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
                if (catalog.ToString().Contains(query))
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
                if (state.ToString().Contains(query))
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
                if (e.ToString().Contains(query))
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

        public void AddCatalog(string name, string genus, int height, string uuid) => repository.AddCatalog(new Catalog(name, genus, height, uuid));

        public void AddEvent(User user, State state, DateTime purchaseDate) => repository.AddEvent(new Event(user, state, purchaseDate));

        public void AddState(Catalog catalog, int amount, double price, DateTime purchaseDate) => repository.AddState(new State(catalog, amount, price, purchaseDate));
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
