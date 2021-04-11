using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDataApi
    {
        #region User CRUD
        void AddUser(User user);

        User GetUser(string uuid);

        IEnumerable<User> GetAllUsers();

        void UpdateUser(string uuid, User user);

        void DeleteUser(string uuid);
        #endregion


        #region Catalog CRUD
        void AddCatalog(Catalog catalog);

        Catalog GetCatalog(string uuid);

        IEnumerable<Catalog> GetAllCatalogs();

        void UpdateCatalog(string uuid, Catalog catalog);

        void DeleteCatalog(string uuid);
        #endregion


        #region Event CR(U)D
        void AddEvent(Event e);

        Event GetEvent(int position);

        IEnumerable<Event> GetAllEvents();

        void DeleteEvent(Event e);

        void DeleteEvent(int position);
        #endregion


        #region State CRUD
        void AddState(State state);

        State GetState(int position);

        State GetCatalogState(string catalogUuid);

        IEnumerable<State> GetAllStates();

        void UpdateState(string catalogUuid, int newAmount);

        void DeleteState(State state);
        #endregion

    }
}
