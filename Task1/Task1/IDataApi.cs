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
        void AddUser(string firstName, string lastName);

        void AddUser(string firstName, string lastName, string uuid);

        IUser GetUser(string uuid);

        IEnumerable<IUser> GetAllUsers();

        void UpdateUser(string uuid, string firstName, string lastName);

        void DeleteUser(string uuid);
        #endregion


        #region Catalog CRUD
        void AddCatalog(string name, string genus, double price);

        void AddCatalog(string name, string genus, double price, string uuid);

        ICatalog GetCatalog(string uuid);

        IEnumerable<ICatalog> GetAllCatalogs();

        void UpdateCatalog(string uuid, string name, string genus, double price);

        void DeleteCatalog(string uuid);
        #endregion


        #region Event CR(U)D
        void AddBuyEvent(IUser user, IState state, DateTime timestamp);

        void AddRestockEvent(IUser user, IState state, DateTime timestamp);

        IEvent GetEvent(int position);

        IEnumerable<IEvent> GetAllEvents();

        void DeleteEvent(IEvent e);

        void DeleteEvent(int position);
        #endregion


        #region State CRUD
        void AddState(ICatalog catalog, int amount);

        IState GetState(int position);

        IState GetCatalogState(string catalogUuid);

        IEnumerable<IState> GetAllStates();

        void UpdateState(string catalogUuid, int newAmount);

        void DeleteState(IState state);
        #endregion

    }
}
