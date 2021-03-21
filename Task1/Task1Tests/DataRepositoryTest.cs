using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;
using System;

namespace Task1Tests
{
    [TestClass]
    public class DataRepositoryTest
    {
        #region User
        [TestMethod]
        public void AddUser_NewEqualsAdded()
        {
            DataContext context = new DataContext();
            FillWithConstants fill = new FillWithConstants();

            DataRepository repository = new DataRepository(context, fill);
            repository.FillData();

            string newUserUuid = Guid.NewGuid().ToString();

            User user = new User("Tonald", "Drump", newUserUuid);
            repository.AddUser(user);

            Assert.IsTrue(user.Equals(repository.GetUser(newUserUuid)));
        }
        #endregion
    }
}
