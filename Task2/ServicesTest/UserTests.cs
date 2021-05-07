using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Services.DTOModels;
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
            UserCRUD userService = new UserCRUD();

            Assert.IsTrue(userService.AddUser(67, "Jan", "Paweł the second"));
            Assert.IsTrue(userService.DeleteUser(67));
        }

        [TestMethod]
        public void GetUserTest()
        {
            UserCRUD userService = new UserCRUD();

            userService.AddUser(88, "Chloe", "Price");

            Assert.AreEqual(userService.GetUser(88).FirstName, "Chloe");

            userService.DeleteUser(88);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            UserCRUD userService = new UserCRUD();

            userService.AddUser(11, "Max", "Verstappen");

            Assert.IsTrue(userService.UpdateLastName(11, "Caulfield"));
            Assert.AreEqual(userService.GetUser(11).LastName, "Caulfield");

            Assert.IsTrue(userService.UpdateFirstName(11, "Timothy"));
            Assert.AreEqual(userService.GetUser(11).FirstName, "Timothy");

            userService.DeleteUser(11);
        }

        [TestMethod]
        public void GetUsersTest()
        {
            UserCRUD userService = new UserCRUD();

            userService.AddUser(16, "Wartłomiej", "Błodarski");
            userService.AddUser(19, "Kaciej", "Mopa");
            userService.AddUser(22, "Wartłomiej", "Bubicki");

            IEnumerable<UserDTO> users = userService.GetAllUsers();

            Assert.AreEqual(users.Count(), 3);

            userService.DeleteUser(16);
            userService.DeleteUser(19);
            userService.DeleteUser(22);
        }
    }
}
