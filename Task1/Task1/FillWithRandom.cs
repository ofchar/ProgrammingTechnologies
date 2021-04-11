using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Fill
{
    public class FillWithRandom : IDataFill
    {
        private Random random;

        public FillWithRandom() 
        {
            random = new Random();
        }


        #region utils
        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnoprstuvwxyz0123456789";

            string generatedString = new string(Enumerable.Repeat(chars, length)
                               .Select(s => s[random.Next(s.Length)]).ToArray());

            return generatedString;
        }

        private double GenerateRandomPrice(double min, double max)
        {
            double price = random.NextDouble() * (max - min) + min;

            return price;
        }
        #endregion


        public void Fill(DataContext context)
        {
            for(int i = 0; i < 10; i++)
            {
                User user = new User(GenerateRandomString(10), GenerateRandomString(10), Guid.NewGuid().ToString());
                context.users.Add(user);

                Catalog catalog = new Catalog(GenerateRandomString(5), GenerateRandomString(10),
                                         GenerateRandomPrice(5, 50), Guid.NewGuid().ToString());
                context.catalogs.Add(catalog);
            }
        }
    }
}
