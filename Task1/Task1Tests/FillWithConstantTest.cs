using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;
using System.Linq;

namespace Task1DataTests
{
    [TestClass]
    public class FillWithConstantTest
    {
        #region utils
        private DataRepository PrepareRepository()
        {
            DataContext context = new DataContext();
            DataRepository repository = new DataRepository(context);

            IDataFill fill = new FillWithConstants();
            fill.Fill(context);

            return repository;
        }
        #endregion



        [TestMethod]
        public void DataCountTest()
        {
            DataRepository repository = PrepareRepository();

            List<IUser> users = (List<IUser>)repository.GetAllUsers();
            Assert.AreEqual(5, users.Count);

            List<ICatalog> catalogs = (List<ICatalog>)repository.GetAllCatalogs();
            Assert.AreEqual(5, catalogs.Count);

            List<IState> states = (List<IState>)repository.GetAllStates();
            Assert.AreEqual(5, states.Count);

            List<IEvent> events = (List<IEvent>)repository.GetAllEvents();
            Assert.AreEqual(5, events.Count);
        }

        [TestMethod]
        public void UserGenerationTest()
        {
            DataRepository repository = PrepareRepository();

            List<IUser> users = (List<IUser>)repository.GetAllUsers();

            Assert.AreEqual("Pukasz", users[0].FirstName);
            Assert.AreEqual("Wowner", users[2].LastName);
        }

        [TestMethod]
        public void CatalogGenerationTest()
        {
            DataRepository repository = PrepareRepository();

            List<ICatalog> catalogs = (List<ICatalog>)repository.GetAllCatalogs();

            Assert.AreEqual("Zamioculcas zamiifolia", catalogs[0].Name);
            Assert.AreEqual("Aloe", catalogs[2].Genus);
            Assert.AreEqual(200, catalogs[3].Price);
        }
    }
}
