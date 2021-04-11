using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataRepository : IDataApi
    {
        private DataContext context;

        public DataRepository(DataContext context)
        {
            this.context = context;
        }



        //C.R.U.D.
        #region User
        private bool doesUserExist(string uuid)
        {
            return context.users.Exists(user => user.Uuid == uuid);
        }


        public void AddUser(User user)
        {
            if(doesUserExist(user.Uuid))
            {
                throw new Exception("User with this uuid already exists");
            }

            context.users.Add(user);
        }

        public User GetUser(string uuid)
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

        public IEnumerable<User> GetAllUsers()
        {
            return context.users;
        }

        public void UpdateUser(string uuid, User user)
        {
            User temp = context.users.First(u => u.Uuid == uuid);

            temp.FirstName = user.FirstName;
            temp.LastName = user.LastName;
            temp.Uuid = user.Uuid;
        }

        public void DeleteUser(string uuid)
        {
            User user = GetUser(uuid);

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
            return context.catalogs.Exists(catalog => catalog.Uuid == uuid);
        }


        public void AddCatalog(Catalog catalog)
        {
            if (doesCatalogExist(catalog.Uuid))
            {
                throw new Exception("Catalog with this uuid already exists");
            }

            context.catalogs.Add(catalog);
        }

        public Catalog GetCatalog(string uuid)
        {
            foreach (var c in context.catalogs)
            {
                if (c.Uuid == uuid)
                {
                    return c;
                }
            }

            throw new Exception("There is no such Catalog");
        }

        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return context.catalogs;
        }

        public void UpdateCatalog(string uuid, Catalog catalog)
        {
            Catalog temp = context.catalogs.First(c => c.Uuid == uuid);

            temp.Name = catalog.Name;
            temp.Genus = catalog.Genus;
            temp.Price = catalog.Price;
            temp.Uuid = catalog.Uuid;
        }

        public void DeleteCatalog(string uuid)
        {
            Catalog catalog = GetCatalog(uuid);

            foreach (State state in context.states)
            {
                if (state.Catalog == catalog)
                {
                    throw new Exception("This Catalog is connected to at least one state");
                }
            }

            context.catalogs.Remove(catalog);
        }
        #endregion


        #region Event
        public void AddEvent(Event e)
        {
            context.events.Add(e);
        }

        public Event GetEvent(int position)
        {
            if(position > context.events.Count)
            {
                throw new Exception("There is no event at this position");
            }

            return context.events[position];
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return context.events;
        }

        public void DeleteEvent(Event e)
        {
            context.events.Remove(e);
        }

        public void DeleteEvent(int position)
        {
            Event e = GetEvent(position);

            context.events.Remove(e);
        }
        #endregion


        #region State
        public void AddState(State state)
        {
            context.states.Add(state);
        }

        public State GetState(int position)
        {
            return context.states[position];
        }

        public State GetCatalogState(string catalogUuid)
        {
            State temp = context.states.Last(state => state.Catalog.Uuid == catalogUuid);

            return temp;
        }

        public IEnumerable<State> GetAllStates()
        {
            return context.states;
        }

        public void UpdateState(string catalogUuid, int newAmount)
        {
            State temp = GetCatalogState(catalogUuid);

            temp.Amount = newAmount;
        }

        public void DeleteState(State state)
        {
            foreach(Event e in context.events)
            {
                if(e.State.Equals(state))
                {
                    throw new Exception("State is used");
                }
            }

            context.states.Remove(state);
        }
        #endregion
    }
}
