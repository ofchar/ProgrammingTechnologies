using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CatalogCRUD
    {
        public CatalogCRUD()
        {
        }

        static public bool AddCatalog(int id, string name, string genus, int price, int quantity)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                if (GetCatalog(id) == null && quantity >= 0)
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

                    return true;
                }
            }

            return false;   
        }

        static public catalog GetCatalog(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (catalog catalog in context.catalogs.ToList())
                {
                    if (catalog.catalog_id == id)
                    {
                        return catalog;
                    }
                }

                return null;
            }
        }

        static public IEnumerable<catalog> GetAllCatalogs()
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                var result = context.catalogs.ToList();

                return result;
            }
        }

        static public catalog GetCatalogByName(string name)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                foreach (catalog catalog in context.catalogs.ToList())
                {
                    if (catalog.catalog_name == name)
                    {
                        return catalog;
                    }
                }
                return null;
            }
        }

        static public IEnumerable<catalog> GetCatalogsByGenus(string genus)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                List<catalog> result = new List<catalog>();

                foreach (catalog catalog in context.catalogs)
                {
                    if (catalog.catalog_genus.Equals(genus))
                    {
                        result.Add(catalog);
                    }
                }
                return result;
            }
        }

        static public List<Dictionary<string, string>> GetCatalogsInfo()
        {
            List<Dictionary<string, string>> returnList = new List<Dictionary<string, string>>();

            List<catalog> tempCatalogs = GetAllCatalogs().ToList();

            foreach (catalog catalog in tempCatalogs)
            {
                Dictionary<string, string> temp = new Dictionary<string, string>();

                temp.Add("id", catalog.catalog_id.ToString());
                temp.Add("name", catalog.catalog_name);
                temp.Add("genus", catalog.catalog_genus);
                temp.Add("price", catalog.catalog_price.ToString());
                temp.Add("quantity", catalog.catalog_quantity.ToString());

                returnList.Add(temp);
            }

            return returnList;
        }

        static public Dictionary<string, string> GetCatalogInfo(int catalog_id)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();

            catalog cat = GetCatalog(catalog_id);

            temp.Add("id", cat.catalog_id.ToString());
            temp.Add("name", cat.catalog_name);
            temp.Add("genus", cat.catalog_genus);
            temp.Add("price", cat.catalog_price.ToString());
            temp.Add("quantity", cat.catalog_quantity.ToString());

            return temp;
        }

        static public bool UpdateName(int id, string name)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                catalog catalog = context.catalogs.SingleOrDefault(cat => cat.catalog_id == id);

                catalog.catalog_name = name;

                context.SubmitChanges();

                return true;
            }
        }

        static public bool UpdateGenus(int id, string genus)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                catalog catalog = context.catalogs.SingleOrDefault(cat => cat.catalog_id == id);

                catalog.catalog_genus = genus;

                context.SubmitChanges();

                return true;
            }
        }

        static public bool UpdatePrice(int id, int price)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                catalog catalog = context.catalogs.SingleOrDefault(cat => cat.catalog_id == id);

                catalog.catalog_price = price;

                context.SubmitChanges();

                return true;
            }
        }

        static public bool UpdateQuantity(int id, int quantity)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                catalog catalog = context.catalogs.SingleOrDefault(cat => cat.catalog_id == id);

                catalog.catalog_quantity = quantity;

                context.SubmitChanges();

                return true;
            }
        }

        static public bool DeleteCatalog(int id)
        {
            using (DataClasses1DataContext context = new DataClasses1DataContext())
            {
                catalog catalog = context.catalogs.SingleOrDefault(cat => cat.catalog_id == id);

                context.catalogs.DeleteOnSubmit(catalog);

                context.SubmitChanges();

                return true;
            }
        }
    }
}
