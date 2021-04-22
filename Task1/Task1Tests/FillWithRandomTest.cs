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

            List<IUser> users = (List<IUser>)repository.GetAllUsers();
            Assert.AreEqual(10, users.Count);

            List<ICatalog> catalogs = (List<ICatalog>)repository.GetAllCatalogs();
            Assert.AreEqual(10, catalogs.Count);

            List<IState> states = (List<IState>)repository.GetAllStates();
            Assert.AreEqual(0, states.Count);

            List<IEvent> events = (List<IEvent>)repository.GetAllEvents();
            Assert.AreEqual(0, events.Count);
        }
    }
}
