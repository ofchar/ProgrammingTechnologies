using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository : IDataApi
    {
        private DataClasses1DataContext context;

        public Repository()
        {
            context = new DataClasses1DataContext();
        }

        public Repository(string sqlString)
        {
            context = new DataClasses1DataContext(sqlString);
        }

        #region User CRUD
        private IUser Map(user user)
        {
            if (user == null)
            {
                return null;
            }

            return new User(user.user_id, user.user_first_name, user.user_last_name);
        }



        public void AddUser(string firstName, string lastName)
        {
            var newUser = new user
            {
                user_id = context.users.Count() + 1,
                user_first_name = firstName,
                user_last_name = lastName
            };

            context.users.InsertOnSubmit(newUser);
            context.SubmitChanges();
        }

        public void AddUser(int id, string firstName, string lastName)
        {
            var newUser = new user
            {
                user_id = id,
                user_first_name = firstName,
                user_last_name = lastName
            };

            context.users.InsertOnSubmit(newUser);
            context.SubmitChanges();
        }

        public IUser GetUser(int id)
        {
            user user = context.users.FirstOrDefault(u => u.user_id == id);

            return Map(user);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            var us = from u in context.users
                     select Map(u);

            return us;
        }

        public void UpdateUserFirstName(int id, string firstName)
        {
            user user = context.users.FirstOrDefault(usr => usr.user_id == id);

            user.user_first_name = firstName;

            context.SubmitChanges();
        }

        public void UpdateUserLastName(int id, string lastName)
        {
            user user = context.users.FirstOrDefault(usr => usr.user_id == id);

            user.user_last_name = lastName;

            context.SubmitChanges();
        }

        public void DeleteUser(int id)
        {
            user user = context.users.FirstOrDefault(usr => usr.user_id == id);

            context.users.DeleteOnSubmit(user);

            context.SubmitChanges();
        }
        #endregion


        #region Catalog CRUD
        private ICatalog Map(catalog catalog)
        {
            if (catalog == null)
            {
                return null;
            }

            return new Catalog(catalog.catalog_id, catalog.catalog_name,
                catalog.catalog_genus, (int)catalog.catalog_quantity, (int)catalog.catalog_price);
        }



        public void AddCatalog(string name, string genus, int quantity, int price)
        {
            catalog newCatalog = new catalog
            {
                catalog_id = context.catalogs.Count() + 1,
                catalog_name = name,
                catalog_genus = genus,
                catalog_price = price,
                catalog_quantity = 0,
            };
            context.catalogs.InsertOnSubmit(newCatalog);
            context.SubmitChanges();
        }

        public void AddCatalog(int id, string name, string genus, int quantity, int price)
        {
            catalog newCatalog = new catalog
            {
                catalog_id = id,
                catalog_name = name,
                catalog_genus = genus,
                catalog_price = price,
                catalog_quantity = quantity,

            };
            context.catalogs.InsertOnSubmit(newCatalog);
            context.SubmitChanges();
        }

        public ICatalog GetCatalog(int id)
        {
            catalog catalog = context.catalogs.FirstOrDefault(cat => cat.catalog_id == id);

            return Map(catalog);
        }

        public IEnumerable<ICatalog> GetAllCatalogs()
        {
            var cs = from c in context.catalogs
                     select Map(c);

            return cs;
        }

        public void UpdateCatalogName(int id, string name)
        {
            catalog catalog = context.catalogs.FirstOrDefault(cat => cat.catalog_id == id);

            catalog.catalog_name = name;

            context.SubmitChanges();
        }

        public void UpdateCatalogGenus(int id, string genus)
        {
            catalog catalog = context.catalogs.FirstOrDefault(cat => cat.catalog_id == id);

            catalog.catalog_genus = genus;

            context.SubmitChanges();
        }

        public void UpdateCatalogQuantity(int id, int quantity)
        {
            catalog catalog = context.catalogs.FirstOrDefault(cat => cat.catalog_id == id);

            catalog.catalog_quantity = quantity;

            context.SubmitChanges();
        }

        public void UpdateCatalogPrice(int id, int price)
        {
            catalog catalog = context.catalogs.FirstOrDefault(cat => cat.catalog_id == id);

            catalog.catalog_price = price;

            context.SubmitChanges();
        }

        public void DeleteCatalog(int id)
        {
            catalog catalog = context.catalogs.FirstOrDefault(cat => cat.catalog_id == id);

            context.catalogs.DeleteOnSubmit(catalog);

            context.SubmitChanges();
        }
        #endregion


        #region Event CR(U)D
        private IEvent Map(@event e)
        {
            if (e == null)
            {
                return null;
            }

            if(e.event_is_stocking)
            {
                return new RestockEvent(e.event_id, e.event_timestamp, e.event_amount, e.catalog_id, e.user_id);
            }
            else
            {
                return new BuyEvent(e.event_id, e.event_timestamp, e.event_amount, e.catalog_id, e.user_id);
            }
        }



        public void AddEvent(int id, DateTime timestamp, bool isStocking, int amount, int catalogId, int userId)
        {
            @event newevent = new @event
            {
                event_id = id,
                event_timestamp = timestamp,
                event_is_stocking = isStocking,
                event_amount = amount,
                catalog_id = catalogId,
                user_id = userId
            };

            context.@event.InsertOnSubmit(newevent);
            context.SubmitChanges();
        }

        public void AddBuyEvent(int id, DateTime timestamp, int amount, int catalogId, int userId)
        {
            @event newevent = new @event
            {
                event_id = id,
                event_timestamp = timestamp,
                event_is_stocking = false,
                event_amount = amount,
                catalog_id = catalogId,
                user_id = userId
            };

            context.@event.InsertOnSubmit(newevent);
            context.SubmitChanges();
        }

        public void AddBuyEvent(DateTime timestamp, int amount, int catalogId, int userId)
        {
            @event newevent = new @event
            {
                event_id = context.@event.Count() + 1,
                event_timestamp = timestamp,
                event_is_stocking = false,
                event_amount = amount,
                catalog_id = catalogId,
                user_id = userId
            };

            context.@event.InsertOnSubmit(newevent);
            context.SubmitChanges();
        }

        public void AddRestockEvent(int id, DateTime timestamp, int amount, int catalogId, int userId)
        {
            @event newevent = new @event
            {
                event_id = id,
                event_timestamp = timestamp,
                event_is_stocking = true,
                event_amount = amount,
                catalog_id = catalogId,
                user_id = userId
            };

            context.@event.InsertOnSubmit(newevent);
            context.SubmitChanges();
        }

        public void AddRestockEvent(DateTime timestamp, int amount, int catalogId, int userId)
        {
            @event newevent = new @event
            {
                event_id = context.@event.Count() + 1,
                event_timestamp = timestamp,
                event_is_stocking = false,
                event_amount = amount,
                catalog_id = catalogId,
                user_id = userId
            };

            context.@event.InsertOnSubmit(newevent);
            context.SubmitChanges();
        }

        public IEvent GetEvent(int id)
        {
            @event e = context.@event.FirstOrDefault(ev => ev.event_id == id);

            return Map(e);
        }

        public IEnumerable<IEvent> GetAllEvents()
        {
            var es = from e in context.@event
                     select Map(e);

            return es.ToList();
        }

        public void DeleteEvent(int id)
        {
            @event myEvent = context.@event.FirstOrDefault(@event => @event.event_id == id);

            context.@event.DeleteOnSubmit(myEvent);

            context.SubmitChanges();
        }

        public void BuyCatalog(int catalog_id, int user_id, int amount)
        {
            if (GetCatalog(catalog_id) != null && GetUser(user_id) != null)
            {
                if (GetCatalog(catalog_id).Quantity >= amount)
                {
                    int eId = context.@event.Count() + 1;
                    
                    AddBuyEvent(eId, DateTime.Today, amount, catalog_id, user_id);

                    UpdateCatalogQuantity(catalog_id, (GetCatalog(catalog_id).Quantity - amount));
                }
                else
                {
                    throw new Exception("not enough product in stock");
                }
            }
        }

        public void RestockCatalog(int catalog_id, int user_id, int amount)
        {
            if (GetCatalog(catalog_id) != null && GetUser(user_id) != null)
            {
                int eId = context.@event.Count() + 1;

                AddRestockEvent(eId, DateTime.Today, amount, catalog_id, user_id);

                UpdateCatalogQuantity(catalog_id, (GetCatalog(catalog_id).Quantity + amount));
            }
        }
        #endregion




        public void NukeTheData()
        {
            context.ExecuteCommand("DELETE FROM events");
            context.ExecuteCommand("DELETE FROM catalogs");
            context.ExecuteCommand("DELETE FROM users");
        }
    }
}
