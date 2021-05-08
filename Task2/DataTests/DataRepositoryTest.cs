using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    [TestClass]
    public class DataRepositoryTest
    {
        public DataRepositoryTest()
        {
            Repository repository = new Repository();
            
            repository.NukeTheData();
        }


        [TestMethod]
        public void AddUser_GetAdded_DeleteTest()
        {
            Repository repository = new Repository();
            repository.AddUser(420, "Pukasz", "Łorembski");

            Assert.AreEqual("Pukasz", repository.GetUser(420).FirstName);

            repository.DeleteUser(420);
            Assert.IsNull(repository.GetUser(420));
        }

        [TestMethod]
        public void AddUsers_GetAllAdded()
        {
            Repository repository = new Repository();
            
            repository.AddUser(420, "Pukasz", "Łorembski");
            repository.AddUser(421, "i have no", "idea for new names");

            Assert.AreEqual(2, repository.GetAllUsers().Count());

            repository.DeleteUser(420);
            repository.DeleteUser(421);
        }

        [TestMethod]
        public void AddUser_UpdateName()
        {
            Repository repository = new Repository();
            repository.AddUser(420, "Pukasz", "Łorembski");

            Assert.AreEqual("Pukasz", repository.GetUser(420).FirstName);

            repository.UpdateUserFirstName(420, "Kukasz");
            Assert.AreEqual("Kukasz", repository.GetUser(420).FirstName);

            repository.DeleteUser(420);
        }



        [TestMethod]
        public void AddCatalog_GetAdded_DeleteTest()
        {
            Repository repository = new Repository();
            repository.AddCatalog(420, "flower", "genus", 10, 15);

            Assert.AreEqual("flower", repository.GetCatalog(420).Name);

            repository.DeleteCatalog(420);
            Assert.IsNull(repository.GetCatalog(420));
        }

        [TestMethod]
        public void AddCatalogs_GetAllAdded()
        {
            Repository repository = new Repository();

            repository.AddCatalog(420, "flower", "genus", 10, 15);
            repository.AddCatalog(421, "another flower", "please end", 11, 16);

            Assert.AreEqual(2, repository.GetAllCatalogs().Count());

            repository.DeleteCatalog(420);
            repository.DeleteCatalog(421);
        }

        [TestMethod]
        public void AddCatalog_UpdateName()
        {
            Repository repository = new Repository();
            repository.AddCatalog(420, "flower", "genus", 10, 15);

            Assert.AreEqual("flower", repository.GetCatalog(420).Name);

            repository.UpdateCatalogName(420, "klower");
            Assert.AreEqual("klower", repository.GetCatalog(420).Name);

            repository.DeleteCatalog(420);
        }



        [TestMethod]
        public void AddEvent_GetAdded_DeleteTest()
        {
            Repository repository = new Repository();
            repository.AddUser(240, "Pukasz", "Łorembski");
            repository.AddCatalog(420, "flower", "genus", 10, 15);

            repository.AddEvent(1, DateTime.Now, false, 10, 420, 240);

            Assert.AreEqual(1, repository.GetAllEvents().Count());
            Assert.AreEqual(420, repository.GetEvent(1).CatalogId);

            repository.DeleteEvent(1);
            repository.DeleteCatalog(420);
            repository.DeleteUser(240);
        }

    }
}
