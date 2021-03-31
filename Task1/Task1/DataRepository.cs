using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class DataRepository
    {
        private DataContext context;
        private IDataFill fill;

        public DataRepository(DataContext context, IDataFill fill)
        {
            this.context = context;
            this.fill = fill;
        }

        public void FillData() => fill.Fill(context);

        //C.R.U.D.
        #region User
        public void AddUser(User user)
        {
            context.users.Add(user);
        }

        public User GetUser(string uuid)
        {
            foreach (var u in context.users)
            {
                if (u.Uuid == uuid)
                {
                    return u;
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

            temp = user;
        }

        public void DeleteUser(User user)
        {
            foreach (Event e in context.events)
            {
                if (e.User == user)
                {
                    throw new Exception("This user is connected to at least one event");
                }
            }

            context.users.Remove(user);
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
        public void AddCatalog(Catalog catalog)
        {
            context.catalogs.Add(catalog);
        }

        public Catalog GetCatalog(int pos)
        {
            return context.catalogs[pos];
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

            temp = catalog;
        }

        public void DeleteCatalog(Catalog catalog)
        {
            foreach (State state in context.states)
            {
                if(state.Catalog == catalog)
                {
                    throw new Exception("This Catalog is connected to at least one state");
                }
            }

            context.catalogs.Remove(catalog);
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

        public IEnumerable<State> GetAllStates()
        {
            return context.states;
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

        public void DeleteState(int position)
        {
            State state = GetState(position);

            foreach (Event e in context.events)
            {
                if (e.State.Equals(state))
                {
                    throw new Exception("State is used");
                }
            }

            context.states.Remove(state);
        }
        #endregion
    }
}
