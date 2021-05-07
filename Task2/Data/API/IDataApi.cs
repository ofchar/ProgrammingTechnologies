using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IDataApi
    {
        #region User CRUD
        void AddUser(string firstName, string lastName);

        void AddUser(int id, string firstName, string lastName);

        IUser GetUser(int id);

        IEnumerable<IUser> GetAllUsers();

        void UpdateUserFirstName(int id, string firstName);
        
        void UpdateUserLastName(int id, string lastName);

        void DeleteUser(int id);
        #endregion


        #region Catalog CRUD
        void AddCatalog(string name, string genus, int quantity, int price);

        void AddCatalog(int id, string name, string genus, int quantity, int price);

        ICatalog GetCatalog(int id);

        IEnumerable<ICatalog> GetAllCatalogs();

        void UpdateCatalogName(int id, string name);
        
        void UpdateCatalogGenus(int id, string genus);
        
        void UpdateCatalogQuantity(int id, int quantity);
        
        void UpdateCatalogPrice(int id, int price);

        void DeleteCatalog(int id);
        #endregion


        #region Event CR(U)D
        void AddEvent(int id, DateTime timestamp, bool isStocking, int amount, int catalogId, int userId);

        void AddBuyEvent(int id, DateTime timestamp, int amount, int catalogId, int userId);
        
        void AddBuyEvent(DateTime timestamp, int amount, int catalogId, int userId);

        void AddRestockEvent(int id, DateTime timestamp, int amount, int catalogId, int userId);

        void AddRestockEvent(DateTime timestamp, int amount, int catalogId, int userId);

        IEvent GetEvent(int id);

        IEnumerable<IEvent> GetAllEvents();

        void DeleteEvent(int id);

        void BuyCatalog(int catalog_id, int user_id, int amount);

        void RestockCatalog(int catalog_id, int user_id, int amount);
        #endregion
    }
}
