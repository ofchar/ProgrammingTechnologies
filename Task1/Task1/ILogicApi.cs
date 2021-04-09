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
        List<Event> EventsForUser(User user);

        List<State> StatesForCatalog(Catalog catalog);

        State CurrentCatalogState(Catalog catalog);
        #endregion


        #region Search
        List<User> SearchUser(string query);

        List<Catalog> SearchCatalog(string query);

        List<State> SearchState(string query);

        List<Event> SearchEvent(string query);
        #endregion


        #region Create
        void CreateUser(string firstName, string lastName);

        void CreateCatalog(string name, string genus, int height);

        void CreateState(Catalog catalog, int amount);
        #endregion


        #region Actions
        void Buy(string userUuid, string catalogUuid, DateTime purchaseDate);

        void Restock(string supplierUuid, string catalogUuid, DateTime restockDate, int restockAmount);
        #endregion
    }
}