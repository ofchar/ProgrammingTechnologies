using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class DataService
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

    }
}
