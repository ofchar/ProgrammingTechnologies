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
    public class EventListViewModelTest
    {
        private EventListViewModel PrepareViewModel()
        {
            return new EventListViewModel()
            {
                EventViewModels = new ObservableCollection<EventItemViewModel>
                {
                    new EventItemViewModel(69, DateTime.Now, false, 420, 2137, 7312),
                    new EventItemViewModel(68, DateTime.Now, false, 419, 2136, 7311),
                    new EventItemViewModel(67, DateTime.Now, false, 418, 2135, 7310),
                    new EventItemViewModel(66, DateTime.Now, false, 417, 2134, 7309),
                }
            };
        }


        [TestMethod]
        public void TestOfBeginnings()
        {
            var eventListVM = PrepareViewModel();

            Assert.IsNull(eventListVM.SelectedVM);

            Assert.IsNotNull(eventListVM.BuyCommand);
            Assert.IsNotNull(eventListVM.RestockCommand);
            Assert.IsNotNull(eventListVM.DeleteCommand);
        }

        [TestMethod]
        public void CatalogVMsCreated()
        {
            var eventListVM = PrepareViewModel();

            Assert.IsNotNull(eventListVM.EventViewModels);
            Assert.AreEqual(eventListVM.EventViewModels.Count, 4);
        }

        [TestMethod]
        public void DeleteValidationTest()
        {
            var eventListVM = PrepareViewModel();
            eventListVM.SelectedVM = null;

            var deleteCommand = eventListVM.DeleteCommand;

            bool can = eventListVM.IsEventViewModelSelected;

            Assert.IsFalse(deleteCommand.CanExecute(can));
        }

        [TestMethod]
        public void BuyExecuted()
        {
            var eventListVM = PrepareViewModel();
            var addCommand = eventListVM.BuyCommand;

            eventListVM.CatalogId = 6;
            eventListVM.UserId = 9;

            bool can = eventListVM.CanAdd;

            Assert.IsTrue(addCommand.CanExecute(can));
        }
    }
}
