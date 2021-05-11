using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTest
{
    [TestClass]
    public class CatalogItemViewModelTest
    {
        [TestMethod]
        public void ConstructorTestOrSth()
        {
            var CatalogItemViewModel = new CatalogItemViewModel(69, "testName", "testGenus", 420, 2137);

            Assert.AreEqual(69, CatalogItemViewModel.Id);
            Assert.AreEqual("testName", CatalogItemViewModel.Name);
            Assert.AreEqual("testGenus", CatalogItemViewModel.Genus);
            Assert.AreEqual(420, CatalogItemViewModel.Quantity);
            Assert.AreEqual(2137, CatalogItemViewModel.Price);
        }

        [TestMethod]
        public void CommandCreated()
        {
            var CatalogItemViewModel = new CatalogItemViewModel(69, "testName", "testGenus", 420, 2137);

            var updateCommand = CatalogItemViewModel.UpdateCommand;

            Assert.IsNotNull(updateCommand);
        }

        [TestMethod]
        public void UpdateValidationTest()
        {
            var CatalogItemViewModel = new CatalogItemViewModel(69, "testName", "testGenus", 420, 2137);

            var updateCommand = CatalogItemViewModel.UpdateCommand;

            CatalogItemViewModel.Name = null;

            bool canBeExecuted = CatalogItemViewModel.CanUpdate;

            Assert.IsFalse(updateCommand.CanExecute(canBeExecuted));
        }
    }
}
