using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    interface ILogicApi
    {
        #region Relations
        List<IEvent> EventsForUser(string userUuid);
        
        List<IEvent> EventsForCatalog(string catalogUuid);

        IState CurrentCatalogState(string catalogUuid);
        #endregion


        #region Search
        List<IUser> SearchUser(string query);

        List<ICatalog> SearchCatalog(string query);

        List<IState> SearchState(string query);

        List<IEvent> SearchEvent(string query);
        #endregion


        #region Actions
        void Buy(string userUuid, string catalogUuid, DateTime purchaseDate, int amount);

        void Restock(string supplierUuid, string catalogUuid, DateTime restockDate, int amount);
        #endregion


        #region IUser crud
        void CreateUser(string firstName, string lastName);

        void CreateUser(string firstName, string lastName, string uuid);

        IUser GetUser(string uuid);

        IEnumerable<IUser> GetAllUsers();

        void DeleteUser(string uuid);
        #endregion


        #region ICatalog crud
        void CreateCatalog(string name, string genus, int price);
        
        void CreateCatalog(string name, string genus, int price, string uuid);

        ICatalog GetCatalog(string uuid);
        
        IEnumerable<ICatalog> GetAllCatalogs();

        void DeleteCatalog(string uuid);
        #endregion
    }
}