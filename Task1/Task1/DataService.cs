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
        public List<IEvent> EventsForUser(string userUuid)
        {
            List<IEvent> result = new List<IEvent>();

            foreach (IEvent e in repository.GetAllEvents())
            {
                if (e.User.Uuid == userUuid)
                {
                    result.Add(e);
                }
            }

            return result;
        }

        public List<IEvent> EventsForCatalog(string catalogUuid)
        {
            List<IEvent> result = new List<IEvent>();

            foreach (IEvent e in repository.GetAllEvents())
            {
                if (e.State.Catalog.Uuid == catalogUuid)
                {
                    result.Add(e);
                }
            }

            return result;
        }

        public IState CurrentCatalogState(string catalogUuid)
        {
            return repository.GetCatalogState(catalogUuid);
        }
        #endregion


        #region Search
        public List<IUser> SearchUser(string query)
        {
            List<IUser> results = new List<IUser>();

            foreach (IUser IUser in repository.GetAllUsers())
            {
                if (IUser.ToString().Contains(query))
                {
                    results.Add(IUser);
                }
            }

            return results;
        }

        public List<ICatalog> SearchCatalog(string query)
        {
            List<ICatalog> results = new List<ICatalog>();

            foreach (ICatalog ICatalog in repository.GetAllCatalogs())
            {
                if (ICatalog.ToString().Contains(query))
                {
                    results.Add(ICatalog);
                }
            }

            return results;
        }

        public List<IState> SearchState(string query)
        {
            List<IState> results = new List<IState>();

            foreach (IState IState in repository.GetAllStates())
            {
                if (IState.ToString().Contains(query))
                {
                    results.Add(IState);
                }
            }

            return results;
        }

        public List<IEvent> SearchEvent(string query)
        {
            List<IEvent> results = new List<IEvent>();

            foreach (IEvent e in repository.GetAllEvents())
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
            IUser IUser = repository.GetUser(userUuid);

            IState IState = repository.GetCatalogState(catalogUuid);

            if (IState.Amount < amount)
            {
                throw new Exception("There is not enough stock for this operation");
            }

            repository.AddBuyEvent(IUser, IState, purchaseDate);

            int newAmount = IState.Amount - amount;
            repository.UpdateState(catalogUuid, newAmount);
        }

        public void Restock(string supplierUuid, string catalogUuid, DateTime restockDate, int amount)
        {
            IUser IUser = repository.GetUser(supplierUuid);
            IState IState = repository.GetCatalogState(catalogUuid);

            int newAmount = IState.Amount + amount;

            repository.AddRestockEvent(IUser, IState, restockDate);
            repository.UpdateState(catalogUuid, newAmount);
        }
        #endregion


        #region IUser crud
        public void CreateUser(string firstName, string lastName)
        {
            repository.AddUser(firstName, lastName);
        }

        public void CreateUser(string firstName, string lastName, string uuid)
        {
            repository.AddUser(firstName, lastName, uuid);
        }

        public IUser GetUser(string uuid)
        {
            return repository.GetUser(uuid);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return repository.GetAllUsers();
        }

        public void DeleteUser(string uuid)
        {
            repository.DeleteUser(uuid);
        }
        #endregion


        #region ICatalog crud
        public void CreateCatalog(string name, string genus, int price)
        {
            repository.AddCatalog(name, genus, price);
        }

        public void CreateCatalog(string name, string genus, int price, string uuid)
        {
            repository.AddCatalog(name, genus, price, uuid);
        }

        public ICatalog GetCatalog(string uuid)
        {
            return repository.GetCatalog(uuid);
        }

        public IEnumerable<ICatalog> GetAllCatalogs()
        {
            return repository.GetAllCatalogs();
        }

        public void DeleteCatalog(string uuid)
        {
            repository.DeleteCatalog(uuid);
        }
        #endregion
    }
}
