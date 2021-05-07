using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Services.DTOModels;
using Data.API;

namespace Services
{
    public class CatalogCRUD
    {
        private IDataApi repository;

        public CatalogCRUD()
        {
            repository = new Repository();
        }

        private CatalogDTO Map(ICatalog catalog)
        {
            if(catalog == null)
            {
                return null;
            }

            return new CatalogDTO
            {
                Id = catalog.Id,
                Name = catalog.Name,
                Genus = catalog.Genus,
                Quantity = catalog.Quantity,
                Price = catalog.Price
            };
        }



        public bool AddCatalog(int id, string name, string genus, int price, int quantity)
        {
            repository.AddCatalog(id, name, genus, quantity, price);

            return true;
        }

        public bool AddCatalog(string name, string genus, int price)
        {
            repository.AddCatalog(name, genus, 0, price);

            return true;
        }

        public CatalogDTO GetCatalog(int id)
        {
            return Map(repository.GetCatalog(id));
        }

        public IEnumerable<CatalogDTO> GetAllCatalogs()
        {
            var catalogs = repository.GetAllCatalogs();
            var result = new List<CatalogDTO>();

            foreach (var catalog in catalogs)
            {
                result.Add(Map(catalog));
            }

            return result;
        }

        public bool UpdateName(int id, string name)
        {
            repository.UpdateCatalogName(id, name);

            return true;
        }

        public bool UpdateGenus(int id, string genus)
        {
            repository.UpdateCatalogGenus(id, genus);

            return true;
        }

        public bool UpdatePrice(int id, int price)
        {
            repository.UpdateCatalogPrice(id, price);

            return true;
        }

        public bool UpdateQuantity(int id, int quantity)
        {
            repository.UpdateCatalogQuantity(id, quantity);

            return true;
        }

        public bool DeleteCatalog(int id)
        {
            repository.DeleteCatalog(id);

            return true;
        }
    }
}
