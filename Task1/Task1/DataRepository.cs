﻿using System;
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

        public void DeleteUser(User w)
        {
            //Todo: make sure that user can be removed

            context.users.Remove(w);
        }

        public void DeleteUser(string uuid)
        {
            User user = GetUser(uuid);

            //Todo: make sure that user can be removed

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

        public void DeleteCatalog(Catalog catalog)
        {
            //Todo: make sure that catalog can be removed

            context.catalogs.Remove(catalog);
        }

        public void DeleteCatalog(string uuid)
        {
            Catalog catalog = GetCatalog(uuid);

            //Todo: make sure that catalog can be removed

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
            //Todo: make sure that event can be removed

            context.events.Remove(e);
        }

        public void DeleteEvent(int position)
        {
            Event e = GetEvent(position);

            //Todo: make sure that event can be removed

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

            //Todo: make sure that state can be removed

            context.states.Remove(state);
        }
        #endregion
    }
}
