using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModels;

namespace PresentationTest
{
    [TestClass]
    public class UserItemViewModelTest
    {
        [TestMethod]
        public void ConstructorTestOrSth()
        {
            var UserItemViewModel = new UserItemViewModel(69, "testName", "testLastName");

            Assert.AreEqual(69, UserItemViewModel.Id);
            Assert.AreEqual("testName", UserItemViewModel.FirstName);
            Assert.AreEqual("testLastName", UserItemViewModel.LastName);
        }

        [TestMethod]
        public void CommandCreated()
        {
            var UserItemViewModel = new UserItemViewModel(69, "testName", "testLastName");

            var updateCommand = UserItemViewModel.UpdateCommand;

            Assert.IsNotNull(updateCommand);
        }

        [TestMethod]
        public void UpdateValidationTest()
        {
            var UserItemViewModel = new UserItemViewModel(69, "testName", "testLastName");

            var updateCommand = UserItemViewModel.UpdateCommand;

            UserItemViewModel.FirstName = null;
            UserItemViewModel.LastName = null;

            bool canBeExecuted = UserItemViewModel.CanUpdate;

            Assert.IsFalse(updateCommand.CanExecute(canBeExecuted));
        }
    }
}
