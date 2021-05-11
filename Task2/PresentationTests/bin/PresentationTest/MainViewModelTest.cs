using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModels;

namespace PresentationTest
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void UserListViewAsDefault()
        {
            MainViewModel mainVM = new MainViewModel();

            Assert.IsInstanceOfType(mainVM.SelectedVM, typeof(UserListViewModel));
        }

        [TestMethod]
        public void SwitchViewToCatalogList()
        {
            MainViewModel mainVM = new MainViewModel();

            mainVM.SwitchView("CatalogListView");

            Assert.IsInstanceOfType(mainVM.SelectedVM, typeof(CatalogListViewModel));
        }
    }
}
