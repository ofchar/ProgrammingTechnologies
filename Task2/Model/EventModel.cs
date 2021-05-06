using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Presentation.Model
{
    class EventModel
    {
        static ObservableCollection<EventModel> models;

        public EventModel()
        {
        }


        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsStocking { get; set; }

        public int Amount { get; set; }

        public int Catalog_id { get; set; }

        public int User_id { get; set; }


        public static ObservableCollection<EventModel> GetCatalogs()
        {
            models = (ObservableCollection<EventModel>)CatalogCRUD.GetAllCatalogs();

            return models;
        }
    }
}
