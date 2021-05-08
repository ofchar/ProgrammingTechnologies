using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTest
{
    public class TestDataRepository : IDataApi
    {
        private List<IUser> users;
        private List<ICatalog> catalogs;
        private List<IEvent> events;

        public TestDataRepository()
        {
            users = new List<IUser>();
            catalogs = new List<ICatalog>();
            events = new List<IEvent>();
        }



        #region User
        public void AddUser(int id, string firstName, string lastName)
        {
            users.Add(new TestUser(id, firstName, lastName));
        }

        public void AddUser(string firstName, string lastName)
        {
            Random rnd = new Random();
            users.Add(new TestUser(rnd.Next(100,100000), firstName, lastName));
        }

        public IUser GetUser(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return users;
        }

        public void UpdateUserFirstName(int id, string firstName)
        {
            users.FirstOrDefault(u => u.Id == id).FirstName = firstName;
        }

        public void UpdateUserLastName(int id, string lastName)
        {
            users.FirstOrDefault(u => u.Id == id).LastName = lastName;
        }

        public void DeleteUser(int id)
        {
            TestUser temp = (TestUser)users.First(u => u.Id == id);

            users.Remove(temp);
        }
        #endregion


        #region Catalog
        public void AddCatalog(int id, string name, string genus, int quantity, int price)
        {
            catalogs.Add(new TestCatalog(id, name, genus, quantity, price));
        }

        public void AddCatalog(string name, string genus, int quantity, int price)
        {
            Random rnd = new Random();

            catalogs.Add(new TestCatalog(rnd.Next(100,100000), name, genus, quantity, price));
        }

        public ICatalog GetCatalog(int id)
        {
            return catalogs.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<ICatalog> GetAllCatalogs()
        {
            return catalogs;
        }

        public void UpdateCatalogName(int id, string name)
        {
            catalogs.FirstOrDefault(c => c.Id == id).Name = name;
        }

        public void UpdateCatalogGenus(int id, string genus)
        {
            catalogs.FirstOrDefault(c => c.Id == id).Genus = genus;
        }

        public void UpdateCatalogQuantity(int id, int quantity)
        {
            catalogs.FirstOrDefault(c => c.Id == id).Quantity = quantity;
        }

        public void UpdateCatalogPrice(int id, int price)
        {
            catalogs.FirstOrDefault(c => c.Id == id).Price = price;
        }

        public void DeleteCatalog(int id)
        {
            TestCatalog catalog = (TestCatalog)catalogs.First(c => c.Id == id);

            catalogs.Remove(catalog);
        }
        #endregion




        #region Event
        public void AddEvent(int id, DateTime timestamp, bool isStocking, int amount, int catalogId, int userId)
        {
            if (isStocking)
                events.Add(new TestRestockEvent(id, timestamp, amount, catalogId, userId));
            else
                events.Add(new TestBuyEvent(id, timestamp, amount, catalogId, userId));
        }

        public void AddBuyEvent(int id, DateTime timestamp, int amount, int catalogId, int userId)
        {
            events.Add(new TestBuyEvent(id, timestamp, amount, catalogId, userId));
        }

        public void AddBuyEvent(DateTime timestamp, int amount, int catalogId, int userId)
        {
            Random rnd = new Random();
            events.Add(new TestBuyEvent(rnd.Next(100,100000), timestamp, amount, catalogId, userId));
        }

        public void AddRestockEvent(int id, DateTime timestamp, int amount, int catalogId, int userId)
        {
            events.Add(new TestRestockEvent(id, timestamp, amount, catalogId, userId));
        }

        public void AddRestockEvent(DateTime timestamp, int amount, int catalogId, int userId)
        {
            Random rnd = new Random();
            events.Add(new TestRestockEvent(rnd.Next(100,1000000), timestamp, amount, catalogId, userId));
        }

        public IEvent GetEvent(int id)
        {
            return events.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<IEvent> GetAllEvents()
        {
            return events;
        }

        public void DeleteEvent(int id)
        {
            IEvent e = events.First(c => c.Id == id);

            events.Remove(e);

        }

        public void BuyCatalog(int catalog_id, int user_id, int amount)
        {
            AddBuyEvent(DateTime.Now, amount, catalog_id, user_id);
        }

        public void RestockCatalog(int catalog_id, int user_id, int amount)
        {
            AddRestockEvent(DateTime.Now, amount, catalog_id, user_id);
        }
        #endregion

    }
}
