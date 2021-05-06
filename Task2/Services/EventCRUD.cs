using Data;
using Services.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EventCRUD
    {
        public EventCRUD()
        { 
        }

        private static EventDTO Map(@event e)
        {
            if (e == null)
            {
                return null;
            }

            return new EventDTO
            {
                Id = e.event_id,
                Timestamp = e.event_timestamp,
                IsStocking= e.event_is_stocking,
                Amount = e.event_amount,
                Catalog_id= e.catalog_id,
                User_id = e.user_id
            };
        }



        static public bool AddEvent(int id, DateTime timestamp, bool isStocking, int amount, int catalog_id, int user_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event newevent = new @event
                {
                    event_id = id,
                    event_timestamp = timestamp,
                    event_is_stocking = isStocking,
                    event_amount = amount,
                    catalog_id = catalog_id,
                    user_id = user_id
                };

                context.@event.InsertOnSubmit(newevent);
                context.SubmitChanges();

                return true;
            }
        }

        static public EventDTO GetEvent(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event e = context.@event.FirstOrDefault(ev => ev.event_id == id);

                return Map(e);
            }
        }

        static public IEnumerable<EventDTO> GetAllEvents()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var es = from e in context.@event
                         select Map(e);

                return es.ToList();
            }
        }

        static public IEnumerable<EventDTO> GetEventsByType(bool type)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var es = from e in context.@event
                         where e.event_is_stocking == type
                         select Map(e);

                return es.ToList();
            }
        }

        static public IEnumerable<EventDTO> GetEventsByCatalog(int catalog_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var es = from e in context.@event
                         where e.catalog_id == catalog_id
                         select Map(e);

                return es.ToList();
            }
        }

        static public IEnumerable<EventDTO> GetEventsByUser(int user_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var es = from e in context.@event
                         where e.user_id == user_id
                         select Map(e);

                return es.ToList();
            }
        }

        static public IEnumerable<EventDTO> GetEventsByUserNames(string firstName, string lastName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                UserDTO user = UserCRUD.GetUserByNames(firstName, lastName);

                var es = from e in context.@event
                         where e.user_id == user.Id
                         select Map(e);

                return es.ToList();
            }
        }

        //static public List<Dictionary<string, string>> GetEventsInfoforUser(string firstName, string lastName)
        //{
        //    List<Dictionary<string, string>> returnList = new List<Dictionary<string, string>>();

        //    List<@event> tempE = GetEventsByUserNames(firstName, lastName).ToList();

        //    foreach (@event e in tempE)
        //    {
        //        Dictionary<string, string> temp = new Dictionary<string, string>();

        //        temp.Add("id", e.event_id.ToString());
        //        temp.Add("timestamp", e.event_timestamp.ToString());
        //        temp.Add("is_stocking", e.event_is_stocking.ToString());
        //        temp.Add("amount", e.event_amount.ToString());
        //        temp.Add("catalog_id", e.catalog_id.ToString());
        //        temp.Add("user_id", e.user_id.ToString());

        //        returnList.Add(temp);
        //    }

        //    return returnList;
        //}

        static public bool DeleteEvent(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.FirstOrDefault(@event => @event.event_id == id);

                context.@event.DeleteOnSubmit(myEvent);

                context.SubmitChanges();

                return true;
            }
        }

        static public bool BuyCatalog(int event_id, int catalog_id, int user_id, int amount)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                if (CatalogCRUD.GetCatalog(catalog_id) != null)
                {
                    if (CatalogCRUD.GetCatalog(catalog_id).Quantity > amount)
                    {
                        AddEvent(event_id, DateTime.Today, false, amount, catalog_id, user_id);

                        CatalogCRUD.UpdateQuantity(catalog_id, (int)(CatalogCRUD.GetCatalog(catalog_id).Quantity - amount));

                        return true;
                    }
                }
            }

            return false;
        }

        static public bool RestockCatalog(int event_id, int catalog_id, int user_id, int amount)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                if (CatalogCRUD.GetCatalog(catalog_id) != null)
                {
                    if (CatalogCRUD.GetCatalog(catalog_id).Quantity > amount)
                    {
                        AddEvent(event_id, DateTime.Today, true, amount, catalog_id, user_id);

                        CatalogCRUD.UpdateQuantity(catalog_id, (int)(CatalogCRUD.GetCatalog(catalog_id).Quantity + amount));

                        return true;
                    }
                }
            }

            return false;
        }


    }
}
