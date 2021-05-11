using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTest
{
    [TestClass]
    public class UserListViewModelTest
    {
        private UserListViewModel PrepareViewModel()
        {
            return new UserListViewModel()
            {
                UserViewModels = new ObservableCollection<UserItemViewModel>()
                {
                    new UserItemViewModel(69, "testName", "testLastName"),
                    new UserItemViewModel(68, "testName2", "testLastName2"),
                    new UserItemViewModel(67, "testName3", "testLastName3"),
                    new UserItemViewModel(66, "testName4", "testLastName4")
                }
            };
        }


        [TestMethod]
        public void TestOfBeginnings()
        {
            var userListVM = PrepareViewModel();

            Assert.IsNull(userListVM.SelectedVM);

            Assert.IsNotNull(userListVM.AddCommand);
            Assert.IsNotNull(userListVM.DeleteCommand);
        }

        [TestMethod]
        public void UserVMsCreated()
        {
            var userListVM = PrepareViewModel();

            Assert.IsNotNull(userListVM.UserViewModels);
            Assert.AreEqual(userListVM.UserViewModels.Count, 4);
        }

        [TestMethod]
        public void DeleteValidationTest()
        {
            var UserListViewModel = PrepareViewModel();
            UserListViewModel.SelectedVM = null;

            var deleteCommand = UserListViewModel.DeleteCommand;

            bool can = UserListViewModel.IsUserViewModelSelected;

            Assert.IsFalse(deleteCommand.CanExecute(can));
        }

        [TestMethod]
        public void AddExecuted()
        {
            var UserListViewModel = PrepareViewModel();
            var addCommand = UserListViewModel.AddCommand;

            UserListViewModel.FirstName = "naaaaaaameeeee";
            UserListViewModel.LastName = "laaaastttnameeeeee";

            bool can = UserListViewModel.CanAdd;

            Assert.IsTrue(addCommand.CanExecute(can));
        }
    }
}
