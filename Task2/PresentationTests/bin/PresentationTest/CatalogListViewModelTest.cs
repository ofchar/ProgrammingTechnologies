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
    public class CatalogListViewModelTest
    {
        private CatalogListViewModel PrepareViewModel()
        {
            return new CatalogListViewModel()
            {
                CatalogViewModels = new ObservableCollection<CatalogItemViewModel>
                {
                    new CatalogItemViewModel(69, "testName", "testGenus", 420, 2137),
                    new CatalogItemViewModel(68, "testName2", "testGenus2", 419, 2136),
                    new CatalogItemViewModel(67, "testName3", "testGenus3", 418, 2135),
                    new CatalogItemViewModel(66, "testName4", "testGenus4", 417, 2134)
                }
            };
        }


        [TestMethod]
        public void TestOfBeginnings()
        {
            var catalogListVM = PrepareViewModel();

            Assert.IsNull(catalogListVM.SelectedVM);

            Assert.IsNotNull(catalogListVM.AddCommand);
            Assert.IsNotNull(catalogListVM.DeleteCommand);
        }

        [TestMethod]
        public void CatalogVMsCreated()
        {
            var catalogListVM = PrepareViewModel();

            Assert.IsNotNull(catalogListVM.CatalogViewModels);
            Assert.AreEqual(catalogListVM.CatalogViewModels.Count, 4);
        }

        [TestMethod]
        public void DeleteValidationTest()
        {
            var catalogListVM = PrepareViewModel();
            catalogListVM.SelectedVM = null;

            var deleteCommand = catalogListVM.DeleteCommand;

            bool can = catalogListVM.IsCatalogViewModelSelected;

            Assert.IsFalse(deleteCommand.CanExecute(can));
        }

        [TestMethod]
        public void AddExecuted()
        {
            var catalogListVM = PrepareViewModel();
            var addCommand = catalogListVM.AddCommand;

            catalogListVM.Name = "naaaame";
            catalogListVM.Genus = "geeeeeeenuuuuus";

            bool can = catalogListVM.CanAdd;

            Assert.IsTrue(addCommand.CanExecute(can));
        }
    }
}
