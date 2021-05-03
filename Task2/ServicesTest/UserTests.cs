using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void AddUserTest()
        {
            Assert.IsTrue(UserCRUD.AddUser(67, "Jan", "Paweł the second"));
            Assert.IsTrue(UserCRUD.DeleteUser(67));
        }

        [TestMethod]
        public void GetUserTest()
        {
            UserCRUD.AddUser(88, "Chloe", "Price");

            Assert.AreEqual(UserCRUD.GetUser(88).user_first_name, "Chloe");
            Assert.AreEqual(UserCRUD.GetUserByLastName("Price").user_id, (88));
            Assert.AreEqual(UserCRUD.GetUserByNames("Chloe", "Price").user_id, 88);

            UserCRUD.DeleteUser(88);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            UserCRUD.AddUser(11, "Max", "Verstappen");

            Assert.IsTrue(UserCRUD.UpdateLastName(11, "Caulfield"));
            Assert.AreEqual(UserCRUD.GetUser(11).user_last_name, "Caulfield");

            Assert.IsTrue(UserCRUD.UpdateFirstName(11, "Timothy"));
            Assert.AreEqual(UserCRUD.GetUserByLastName("Caulfield").user_first_name, "Timothy");

            UserCRUD.DeleteUser(11);
        }

        [TestMethod]
        public void GetUsersTest()
        {
            UserCRUD.AddUser(16, "Wartłomiej", "Błodarski");
            UserCRUD.AddUser(19, "Kaciej", "Mopa");
            UserCRUD.AddUser(22, "Wartłomiej", "Bubicki");

            IEnumerable<user> users = UserCRUD.GetUsersByFirstName("Wartłomiej");

            Assert.AreEqual(users.Count(), 2);
            Assert.AreEqual(users.ElementAt(0).user_last_name, "Błodarski");
            Assert.AreEqual(users.ElementAt(1).user_id, 22);

            UserCRUD.DeleteUser(16);
            UserCRUD.DeleteUser(19);
            UserCRUD.DeleteUser(22);
        }
    }
}
