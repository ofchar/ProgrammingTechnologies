using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class FillWithConstants : IDataFill
    {
        public FillWithConstants() { }

        public void Fill(DataContext context)
        {
            #region Users - shop clients
            context.users.Add(new User("Pukasz", "Lorembski", Guid.NewGuid().ToString()));
            context.users.Add(new User("Zarolina", "Kaborowska", Guid.NewGuid().ToString()));
            context.users.Add(new User("Kojciech", "Wowner", Guid.NewGuid().ToString()));
            context.users.Add(new User("Lobert", "Rewandowski", Guid.NewGuid().ToString()));
            context.users.Add(new User("Barcin", "Mąk", Guid.NewGuid().ToString()));
            #endregion

            #region Catalogs - flowers
            context.catalogs.Add(new Catalog("Zamioculcas zamiifolia", "Zamioculcas", 40, Guid.NewGuid().ToString()));
            context.catalogs.Add(new Catalog("Sansevieria trifasciata", "Sansevieria", 30, Guid.NewGuid().ToString()));
            context.catalogs.Add(new Catalog("Aloe vera", "Aloe", 40, Guid.NewGuid().ToString()));
            context.catalogs.Add(new Catalog("Monstera deliciosa", "Monstera", 200, Guid.NewGuid().ToString()));
            context.catalogs.Add(new Catalog("Monstera adansonii ", "Monstera", 150, Guid.NewGuid().ToString()));
            #endregion

            #region States
            context.states.Add(new State(context.catalogs[0], 12, 25.0, DateTime.Today));
            context.states.Add(new State(context.catalogs[1], 3, 22.0, DateTime.Today));
            context.states.Add(new State(context.catalogs[2], 8, 30.0, DateTime.Today));
            context.states.Add(new State(context.catalogs[3], 2, 130.0, DateTime.Today));
            context.states.Add(new State(context.catalogs[4], 18, 52.0, DateTime.Today));
            #endregion

            #region Events
            for (int c = 0; c < 5; c++) //<-- actually it is c#, not c++.
            {
                context.events.Add(new Event(context.users[c], context.states[c], DateTime.Today));
            }
            #endregion
        }
    }
}
