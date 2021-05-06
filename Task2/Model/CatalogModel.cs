using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Services;

namespace Presentation.Model
{
    public class CatalogModel
    {
        static ObservableCollection<CatalogModel> models;

        public CatalogModel()
        {
        }


        public int Id { get; set; }

        public string Name { get; set; }

        public string Genus { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }


        public static ObservableCollection<CatalogModel> GetCatalogs()
        {
            models = (ObservableCollection<CatalogModel>)CatalogCRUD.GetAllCatalogs();

            return models;
        }
    }
}
