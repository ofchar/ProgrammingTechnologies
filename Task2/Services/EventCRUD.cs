using Data;
using Data.API;
using Services.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class EventCRUD
    {
        private IDataApi repository;

        public EventCRUD()
        {
            repository = new Repository();
        }

        private static EventDTO Map(IEvent e)
        {
            if (e == null)
            {
                return null;
            }

            return new EventDTO
            {
                Id = e.Id,
                Timestamp = e.Timestamp,
                IsStocking= e.IsRestock,
                Amount = e.Amount,
                Catalog_id= e.CatalogId,
                User_id = e.UserId
            };
        }



        public bool AddEvent(int id, DateTime timestamp, bool isStocking, int amount, int catalog_id, int user_id)
        {
            repository.AddEvent(id, timestamp, isStocking, amount, catalog_id, user_id);

            return true;
        }

        public EventDTO GetEvent(int id)
        {
            return Map(repository.GetEvent(id));
        }

        public IEnumerable<EventDTO> GetAllEvents()
        {
            var events = repository.GetAllEvents();
            var result = new List<EventDTO>();

            foreach (var e in events)
            {
                result.Add(Map(e));
            }

            return result;
        }

        public bool DeleteEvent(int id)
        {
            repository.DeleteEvent(id);

            return true;
        }

        public bool BuyCatalog(int catalog_id, int user_id, int amount)
        {
            repository.AddBuyEvent(DateTime.Now, amount, catalog_id, user_id);

            return true;
        }

        public bool RestockCatalog(int catalog_id, int user_id, int amount)
        {
            repository.AddRestockEvent(DateTime.Now, amount, catalog_id, user_id);

            return true;
        }
    }
}
