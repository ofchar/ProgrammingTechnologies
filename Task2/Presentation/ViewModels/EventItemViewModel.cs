using Presentation.ViewModel.MVVMLight;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class EventItemViewModel : ViewModelBase
    {
        #region properties
        private int _Id;
        private DateTime _Timestamp;
        private bool _IsStocking;
        private int _Amount;
        private int _CatalogId;
        private int _UserId;
        #endregion


        public EventItemViewModel(int id, DateTime timestamp, bool isStocking, int amount, int catalogId, int userId)
        {
            _Id = id;
            _Timestamp = timestamp;
            _IsStocking = isStocking;
            _Amount = amount;
            _CatalogId = catalogId;
            _UserId = userId;
        }

        public EventItemViewModel() { }

        #region API
        public int Id
        {
            get => _Id;

            set
            {
                _Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public DateTime Timestamp
        {
            get => _Timestamp;
            set
            {
                _Timestamp = value;

                OnPropertyChanged(nameof(Timestamp));
            }
        }

        public bool IsStocking
        {
            get => _IsStocking;
            set
            {
                _IsStocking = value;

                OnPropertyChanged(nameof(IsStocking));
            }
        }

        public int Amount
        {
            get => _Amount;
            set
            {
                _Amount = value;

                OnPropertyChanged(nameof(Amount));
            }
        }

        public int CatalogId
        {
            get => _CatalogId;
            set
            {
                _CatalogId = value;

                OnPropertyChanged(nameof(CatalogId));
            }
        }

        public int UserId
        {
            get => _UserId;
            set
            {
                _UserId = value;

                OnPropertyChanged(nameof(UserId));
            }
        }

        #endregion
    }
}
