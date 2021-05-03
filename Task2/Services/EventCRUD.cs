using Data;
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
                    catalog_id  = catalog_id,
                    user_id = user_id
                };

                context.@event.InsertOnSubmit(newevent);
                context.SubmitChanges();

                return true;
            }
        }

        static public @event GetEvent(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (@event myevent in context.@event.ToList())
                {
                    if (myevent.event_id == id)
                    {
                        return myevent;
                    }
                }
                return null;
            }
        }

        static public IEnumerable<@event> GetAllEvents()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var result = context.@event.ToList();

                return result;
            }
        }

        static public IEnumerable<@event> GetEventsByTime(DateTime timestamp)
        {
            using (var context = new DataClasses1DataContext())
            {
                List<@event> events = new List<@event>();

                foreach (@event eveent in context.@event.ToList())
                {
                    if (eveent.event_timestamp == timestamp)
                    {
                        events.Add(eveent);
                    }
                }

                return events;
            }
        }

        static public IEnumerable<@event> GetEventsByType(bool type)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<@event> result = new List<@event>();

                foreach (@event myevent in context.@event)
                {
                    if (myevent.event_is_stocking.Equals(type))
                    {
                        result.Add(myevent);
                    }
                }

                return result;
            }
        }

        static public IEnumerable<@event> GetEventsByCatalog(int catalog_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<@event> result = new List<@event>();

                foreach (@event myevent in context.@event)
                {
                    if (myevent.catalog_id.Equals(catalog_id))
                    {
                        result.Add(myevent);
                    }
                }

                return result;
            }
        }

        static public IEnumerable<@event> GetEventsByUser(int user_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<@event> result = new List<@event>();

                foreach (@event myevent in context.@event)
                {
                    if (myevent.user_id.Equals(user_id))
                    {
                        result.Add(myevent);
                    }
                }

                return result;
            }
        }

        static public IEnumerable<@event> GetEventsByUserNames(string firstName, string lastName)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                user user = UserCRUD.GetUserByNames(firstName, lastName);

                List<@event> events = new List<@event>();

                foreach (@event ev in context.@event.ToList())
                {
                    if (ev.user_id == user.user_id)
                    {
                        events.Add(ev);
                    }
                }

                return events;
            }
        }

        static public List<Dictionary<string, string>> GetEventsInfoforUser(string firstName, string lastName)
        {
            List<Dictionary<string, string>> returnList = new List<Dictionary<string, string>>();

            List<@event> tempE = GetEventsByUserNames(firstName, lastName).ToList();

            foreach (@event e in tempE)
            {
                Dictionary<string, string> temp = new Dictionary<string, string>();

                temp.Add("id", e.event_id.ToString());
                temp.Add("timestamp", e.event_timestamp.ToString());
                temp.Add("is_stocking", e.event_is_stocking.ToString());
                temp.Add("amount", e.event_amount.ToString());
                temp.Add("catalog_id", e.catalog_id.ToString());
                temp.Add("user_id", e.user_id.ToString());

                returnList.Add(temp);
            }

            return returnList;
        }

        static public bool DeleteEvent(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                @event myEvent = context.@event.SingleOrDefault(@event => @event.event_id == id);

                context.@event.DeleteOnSubmit(myEvent);

                context.SubmitChanges();

                return true;
            }
        }

        static public void DeleteEventsForUser(int user_id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                IEnumerable<@event> events = context.@event.Where(e => e.user_id == user_id);

                foreach (@event e in events)
                {
                    context.@event.DeleteOnSubmit(e);
                    context.SubmitChanges();
                }
            }
        }

        static public bool BuyCatalog(int event_id, int catalog_id, int user_id, int amount)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                if (CatalogCRUD.GetCatalog(catalog_id) != null)
                {
                    if (CatalogCRUD.GetCatalog(catalog_id).catalog_quantity > amount)
                    {
                        AddEvent(event_id, DateTime.Today, false, amount, catalog_id, user_id);

                        CatalogCRUD.UpdateQuantity(catalog_id, (int)(CatalogCRUD.GetCatalog(catalog_id).catalog_quantity - amount));

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
                    if (CatalogCRUD.GetCatalog(catalog_id).catalog_quantity > amount)
                    {
                        AddEvent(event_id, DateTime.Today, true, amount, catalog_id, user_id);

                        CatalogCRUD.UpdateQuantity(catalog_id, (int)(CatalogCRUD.GetCatalog(catalog_id).catalog_quantity + amount));

                        return true;
                    }
                }
            }

            return false;
        }


    }
}
