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
        List<Event> EventsForUser(string userUuid);
        
        List<Event> EventsForCatalog(string catalogUuid);

        State CurrentCatalogState(string catalogUuid);
        #endregion


        #region Search
        List<User> SearchUser(string query);

        List<Catalog> SearchCatalog(string query);

        List<State> SearchState(string query);

        List<Event> SearchEvent(string query);
        #endregion


        #region Actions
        void Buy(string userUuid, string catalogUuid, DateTime purchaseDate, int amount);

        void Restock(string supplierUuid, string catalogUuid, DateTime restockDate, int amount);
        #endregion


        #region User crud
        void CreateUser(string firstName, string lastName);

        void CreateUser(string firstName, string lastName, string uuid);

        User GetUser(string uuid);

        IEnumerable<User> GetAllUsers();

        void DeleteUser(string uuid);
        #endregion


        #region Catalog crud
        void CreateCatalog(string name, string genus, int price);
        
        void CreateCatalog(string name, string genus, int price, string uuid);

        Catalog GetCatalog(string uuid);
        
        IEnumerable<Catalog> GetAllCatalogs();

        void DeleteCatalog(string uuid);
        #endregion
    }
}