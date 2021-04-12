using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;

namespace Task1DataTests
{
    [TestClass]
    public class FillWithRandomTest
    {
        #region utils
        private DataRepository PrepareRepository()
        {
            DataContext context = new DataContext();
            DataRepository repository = new DataRepository(context);

            IDataFill fill = new FillWithRandom();
            fill.Fill(context);

            return repository;
        }
        #endregion



        [TestMethod]
        public void DataCountTest()
        {
            DataRepository repository = PrepareRepository();

            List<User> users = (List<User>)repository.GetAllUsers();
            Assert.AreEqual(10, users.Count);

            List<Catalog> catalogs = (List<Catalog>)repository.GetAllCatalogs();
            Assert.AreEqual(10, catalogs.Count);

            List<State> states = (List<State>)repository.GetAllStates();
            Assert.AreEqual(0, states.Count);

            List<Event> events = (List<Event>)repository.GetAllEvents();
            Assert.AreEqual(0, events.Count);
        }
    }
}
