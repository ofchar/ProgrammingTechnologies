using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1DataTests
{
    public class FillWithConstants : IDataFill
    {
        public FillWithConstants() { }

        public void Fill(DataContext context)
        {
            #region Users - shop clients
            context.users.Add(new User("Pukasz", "Lorembski", "3beea0f3-3bcb-4dfc-a77e-6abe88aadb9b"));
            context.users.Add(new User("Zarolina", "Kaborowska", "c1434771-7e16-4b94-bd69-6a4240a2d728"));
            context.users.Add(new User("Kojciech", "Wowner", "e0e49ad8-e7a1-44ee-b1ca-396d34e22eee"));
            context.users.Add(new User("Lobert", "Rewandowski", "6c285443-37a0-4347-9e8b-717dd5dfb1e4"));
            context.users.Add(new User("Barcin", "Mąk", "19a94215-4477-47c6-93fa-135563c45ee7"));
            #endregion

            #region Catalogs - flowers
            context.catalogs.Add("6d866448-b7ac-4b03-b5df-e09affd4ec08", 
                    new Catalog("Zamioculcas zamiifolia", "Zamioculcas", 40, "6d866448-b7ac-4b03-b5df-e09affd4ec08"));

            context.catalogs.Add("2133ae57-1fb3-4f4c-86f5-b1c90beea1a0", 
                    new Catalog("Sansevieria trifasciata", "Sansevieria", 30, "2133ae57-1fb3-4f4c-86f5-b1c90beea1a0"));

            context.catalogs.Add("52c9b0ef-76a2-478c-b8b2-233a416f9f64",
                    new Catalog("Aloe vera", "Aloe", 40, "52c9b0ef-76a2-478c-b8b2-233a416f9f64"));

            context.catalogs.Add("87c07f4d-d0ee-4202-97b8-b8da14a22eb7", 
                    new Catalog("Monstera deliciosa", "Monstera", 200, "87c07f4d-d0ee-4202-97b8-b8da14a22eb7"));

            context.catalogs.Add("47ddc515-2cbd-450a-83e9-0fd1ea223182",
                    new Catalog("Monstera adansonii ", "Monstera", 150, "47ddc515-2cbd-450a-83e9-0fd1ea223182"));
            #endregion

            #region States
            context.states.Add(new State(context.catalogs["6d866448-b7ac-4b03-b5df-e09affd4ec08"], 12));
            context.states.Add(new State(context.catalogs["2133ae57-1fb3-4f4c-86f5-b1c90beea1a0"], 3));
            context.states.Add(new State(context.catalogs["52c9b0ef-76a2-478c-b8b2-233a416f9f64"], 8));
            context.states.Add(new State(context.catalogs["87c07f4d-d0ee-4202-97b8-b8da14a22eb7"], 2));
            context.states.Add(new State(context.catalogs["47ddc515-2cbd-450a-83e9-0fd1ea223182"], 18));
            #endregion

            #region Events
            for (int c = 0; c < 5; c++) //<-- actually it is c#, not c++.
            {
                context.events.Add(new BuyEvent(context.users[c], context.states[c], DateTime.Today));
            }
            #endregion
        }
    }
}
