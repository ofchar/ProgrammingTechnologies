using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DataService : ILogicApi
    {
        private IDataApi repository;

        public DataService(IDataApi repository)
        {
            this.repository = repository;
        }


        #region utils
        private string generateUuid()
        {
            return Guid.NewGuid().ToString();
        }
        #endregion



        #region Relations
        public List<Event> EventsForUser(string userUuid)
        {
            List<Event> result = new List<Event>();

            foreach (Event e in repository.GetAllEvents())
            {
                if (e.User.Uuid == userUuid)
                {
                    result.Add(e);
                }
            }

            return result;
        }

        public List<Event> EventsForCatalog(string catalogUuid)
        {
            List<State> result = new List<State>();

            foreach (State state in repository.GetAllStates())
            {
                if (state.Catalog.Uuid == catalogUuid)
                {
                    result.Add(state);
                }
            }

            return result;
        }

        public State CurrentCatalogState(string catalogUuid)
        {
            return repository.GetCurrentCatalogState(catalogUuid);
        }
        #endregion


        #region Search
        public List<User> SearchUser(string query)
        {
            List<User> results = new List<User>();

            foreach (User user in repository.GetAllUsers())
            {
                if (user.ToString().Contains(query))
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


        #region Actions
        public void Buy(string userUuid, string catalogUuid, DateTime purchaseDate, int amount)
        {
            User user = repository.GetUser(userUuid);

            State state = repository.GetCurrentCatalogState(catalogUuid);

            if (state.Amount < amount)
            {
                throw new Exception("There is not enough stock for this operation");
            }

            repository.AddEvent(new BuyEvent(user, state, purchaseDate));

            int newAmount = state.Amount - amount;
            repository.UpdateState(catalogUuid, newAmount);
        }

        public void Restock(string supplierUuid, string catalogUuid, DateTime restockDate, int amount)
        {
            User user = repository.GetUser(supplierUuid);
            State state = repository.GetCurrentCatalogState(catalogUuid);

            int newAmount = state.Amount + amount;

            repository.AddEvent(new RestockEvent(user, state, restockDate));
            repository.UpdateState(catalogUuid, newAmount);
        }
        #endregion


        #region User crud
        public void CreateUser(string firstName, string lastName)
        {
            string generatedUuid = generateUuid();

            User createdUser = new User(firstName, lastName, generatedUuid);

            repository.AddUser(createdUser);
        }

        public void CreateUser(string firstName, string lastName, string uuid)
        {
            User createdUser = new User(firstName, lastName, uuid);

            repository.AddUser(createdUser);
        }

        public User getUser(string uuid)
        {
            return repository.GetUser(uuid);
        }

        public void DeleteUser(string uuid)
        {
            repository.DeleteUser(uuid);
        }
        #endregion


        #region Catalog crud
        public void CreateCatalog(string name, string genus, int price)
        {
            string generatedUuid = generateUuid();

            Catalog createdCatalog = new Catalog(name, genus, price, generatedUuid);

            repository.AddCatalog(createdCatalog);
        }

        public void CreateCatalog(string name, string genus, int price, string uuid)
        {
            Catalog createdCatalog = new Catalog(name, genus, price, uuid);

            repository.AddCatalog(createdCatalog);
        }

        public Catalog getCatalog(string uuid)
        {
            return repository.GetCatalog(uuid);
        }

        public void DeleteCatalog(string uuid)
        {
            repository.DeleteCatalog(uuid);
        }
        #endregion
    }
}
