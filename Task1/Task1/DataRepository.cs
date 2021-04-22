using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataRepository : IDataApi
    {
        private DataContextApi context;

        public DataRepository(DataContextApi context)
        {
            this.context = context;
        }



        //C.R.U.D.
        #region User
        private bool doesUserExist(string uuid)
        {
            return context.users.Exists(user => user.Uuid == uuid);
        }


        public void AddUser(string firstName, string lastName, string uuid)
        {
            if(doesUserExist(uuid))
            {
                throw new Exception("User with this uuid already exists");
            }

            context.users.Add(new User(firstName, lastName, uuid));
        }
        public void AddUser(string firstName, string lastName)
        {
            context.users.Add(new User(firstName, lastName, Guid.NewGuid().ToString()));
        }

        public IUser GetUser(string uuid)
        {
            foreach (User user in context.users)
            {
                if (user.Uuid == uuid)
                {
                    return user;
                }
            }

            throw new Exception("There is no such User");
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return context.users;
        }

        public void UpdateUser(string uuid, string firstName, string lastName)
        {
            User temp = (User)context.users.First(u => u.Uuid == uuid);

            temp.FirstName = firstName;
            temp.LastName = lastName;
        }

        public void DeleteUser(string uuid)
        {
            User user = (User)GetUser(uuid);

            foreach (Event e in context.events)
            {
                if (e.User == user)
                {
                    throw new Exception("This user is connected to at least one event");
                }
            }

            context.users.Remove(user);
        }
        #endregion


        #region Catalog
        private bool doesCatalogExist(string uuid)
        {
            return context.catalogs.ContainsKey(uuid);
        }


        public void AddCatalog(string name, string genus, double price, string uuid)
        {
            if (doesCatalogExist(uuid))
            {
                throw new Exception("Catalog with this uuid already exists");
            }

            Catalog catalog = new Catalog(name, genus, price, uuid);
            context.catalogs.Add(uuid, catalog);

            context.states.Add(new State(catalog, 0));
        }

        public void AddCatalog(string name, string genus, double price)
        {
            string uuid = Guid.NewGuid().ToString();
            Catalog catalog = new Catalog(name, genus, price, uuid);

            context.catalogs.Add(uuid, catalog);

            context.states.Add(new State(catalog, 0));
        }

        public ICatalog GetCatalog(string uuid)
        {
            if(doesCatalogExist(uuid))
            {
                return context.catalogs[uuid];
            }

            throw new Exception("There is no such Catalog");
        }

        public IEnumerable<ICatalog> GetAllCatalogs()
        {
            return context.catalogs.Values.ToList();
        }

        public void UpdateCatalog(string uuid, string name, string genus, double price)
        {
            if(!doesCatalogExist(uuid))
            {
                throw new Exception("There is no such Catalog");
            }

            context.catalogs[uuid].Name = name;
            context.catalogs[uuid].Genus = genus;
            context.catalogs[uuid].Price = price;
        }

        public void DeleteCatalog(string uuid)
        {
            Catalog catalog = (Catalog)GetCatalog(uuid);

            foreach (State state in context.states)
            {
                if (state.Catalog == catalog)
                {
                    throw new Exception("This Catalog is connected to at least one state");
                }
            }

            context.catalogs.Remove(uuid);
        }
        #endregion


        #region Event
        public void AddBuyEvent(IUser user, IState state, DateTime timestamp)
        {
            context.events.Add(new BuyEvent(user, state, timestamp));
        }

        public void AddRestockEvent(IUser user, IState state, DateTime timestamp)
        {
            context.events.Add(new RestockEvent(user, state, timestamp));
        }

        public IEvent GetEvent(int position)
        {
            if(position > context.events.Count)
            {
                throw new Exception("There is no event at this position");
            }

            return context.events[position];
        }

        public IEnumerable<IEvent> GetAllEvents()
        {
            return context.events;
        }

        public void DeleteEvent(IEvent e)
        {
            context.events.Remove((Event)e);
        }

        public void DeleteEvent(int position)
        {
            Event e = (Event)GetEvent(position);

            context.events.Remove(e);
        }
        #endregion


        #region State
        public void AddState(ICatalog catalog, int amount)
        {
            context.states.Add(new State(catalog, amount));
        }

        public IState GetState(int position)
        {
            return context.states[position];
        }

        public IState GetCatalogState(string catalogUuid)
        {
            State temp = (State)context.states.Last(state => state.Catalog.Uuid == catalogUuid);

            return temp;
        }

        public IEnumerable<IState> GetAllStates()
        {
            return context.states;
        }

        public void UpdateState(string catalogUuid, int newAmount)
        {
            State temp = (State)GetCatalogState(catalogUuid);

            temp.Amount = newAmount;
        }

        public void DeleteState(IState state)
        {
            foreach(Event e in context.events)
            {
                if(e.State.Equals(state))
                {
                    throw new Exception("State is used");
                }
            }

            context.states.Remove((State)state);
        }
        #endregion
    }
}
