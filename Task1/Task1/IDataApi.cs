using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    interface IDataApi
    {
        #region User
        void AddUser(User user);

        User GetUser(string uuid);

        IEnumerable<User> GetAllUsers();

        void UpdateUser(string uuid, User user);

        void DeleteUser(User user);

        void DeleteUser(string uuid);
        #endregion


        #region Catalog
        void AddCatalog(Catalog catalog);

        Catalog GetCatalog(int pos);

        Catalog GetCatalog(string uuid);

        IEnumerable<Catalog> GetAllCatalogs();

        void UpdateCatalog(string uuid, Catalog catalog);

        void DeleteCatalog(Catalog catalog);

        void DeleteCatalog(string uuid);
        #endregion


        #region Event
        void AddEvent(Event e);

        Event GetEvent(int position);

        IEnumerable<Event> GetAllEvents();

        void DeleteEvent(Event e);

        void DeleteEvent(int position);
        #endregion


        #region State
        void AddState(State state);

        State GetState(int position);

        IEnumerable<State> GetAllStates();

        void DeleteState(State state);

        void DeleteState(int position);
        #endregion

    }
}
