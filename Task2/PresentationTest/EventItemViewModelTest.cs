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
    public class EventItemViewModelTest
    {
        [TestMethod]
        public void ConstructorTestOrSth()
        {
            DateTime time = DateTime.Now;

            var EventItemViewModel = new EventItemViewModel(69, time, false, 420, 2137, 7312);

            Assert.AreEqual(69, EventItemViewModel.Id);
            Assert.AreEqual(time, EventItemViewModel.Timestamp);
            Assert.IsFalse(EventItemViewModel.IsStocking);
            Assert.AreEqual(420, EventItemViewModel.Amount);
            Assert.AreEqual(2137, EventItemViewModel.CatalogId);
            Assert.AreEqual(7312, EventItemViewModel.UserId);
        }
    }
}