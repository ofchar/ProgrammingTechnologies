using Presentation.ViewModel.MVVMLight;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class EventListViewModel : ViewModelBase
    {
        #region properties
        private int _UserId;
        private int _CatalogId;
        private int _Amount;
        private bool _IsStocking;

        private ICommand _BuyCommand;
        private ICommand _RestockCommand;
        private ICommand _DeleteCommand;

        private EventCRUD _Service;
        private ObservableCollection<EventItemViewModel> _EventViewModels;
        private EventItemViewModel _SelectedViewModel;
        private bool _IsEventViewModelSelected;
        #endregion


        public EventListViewModel()
        {
            _Service = new EventCRUD();
            _EventViewModels = new ObservableCollection<EventItemViewModel>();

            _BuyCommand = new RelayCommand(e => { AddBuyEvent(); },
                condition => CanAdd);

            _RestockCommand = new RelayCommand(e => { AddRestockEvent(); },
                condition => CanAdd);

            _DeleteCommand = new RelayCommand(e => { DeleteEvent(); },
                condition => EventViewModelIsSelected());

            IsEventViewModelSelected = false;

            GetEvents();
        }



        #region private methods
        private void AddBuyEvent()
        {
            if (!_Service.BuyCatalog(CatalogId, UserId, Amount))
            {
                ShowPopup("An error occured :(((");
            }
            GetEvents();
        }

        private void AddRestockEvent()
        {
            _Service.RestockCatalog(CatalogId, UserId, Amount);
            GetEvents();
        }

        private void DeleteEvent()
        {
            _Service.DeleteEvent(SelectedVM.Id);

            GetEvents();
        }

        private void GetEvents()
        {
            _EventViewModels.Clear();

            foreach (var c in _Service.GetAllEvents())
            {
                _EventViewModels.Add(new EventItemViewModel(c.Id, c.Timestamp, c.IsStocking, c.Amount, c.Catalog_id, c.User_id));
            }

            OnPropertyChanged(nameof(EventViewModels));
        }

        private bool EventViewModelIsSelected()
        {
            return !(_SelectedViewModel is null);
        }

        private void ShowPopup(string message)
        {
            MessageBox.Show(message);
        }
        #endregion



        #region API
        public int UserId
        {
            get => _UserId;
            set
            {
                _UserId = value;

                OnPropertyChanged(nameof(UserId));
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

        public int Amount
        {
            get => _Amount;
            set
            {
                _Amount = value;

                OnPropertyChanged(nameof(Amount));
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

        public ICommand BuyCommand
        {
            get => _BuyCommand;
        }

        public ICommand RestockCommand
        {
            get => _RestockCommand;
        }

        public ICommand DeleteCommand
        {
            get => _DeleteCommand;
        }

        public bool IsEventViewModelSelected
        {
            get => _IsEventViewModelSelected;
            set
            {
                IsEventViewModelSelectedVisibility = value ? Visibility.Visible : Visibility.Hidden;
                _IsEventViewModelSelected = value;
                OnPropertyChanged(nameof(IsEventViewModelSelected));
            }
        }

        private Visibility _IsEventViewModelSelectedVisibility;

        public Visibility IsEventViewModelSelectedVisibility
        {
            get => _IsEventViewModelSelectedVisibility;
            set
            {
                _IsEventViewModelSelectedVisibility = value;
                OnPropertyChanged(nameof(IsEventViewModelSelectedVisibility));
            }
        }

        public ObservableCollection<EventItemViewModel> EventViewModels
        {
            get => _EventViewModels;

            set
            {
                _EventViewModels = value;
                OnPropertyChanged(nameof(EventViewModels));
            }
        }

        public EventItemViewModel SelectedVM
        {
            get => _SelectedViewModel;
            set
            {
                _SelectedViewModel = value;
                IsEventViewModelSelected = true;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }

        public bool CanAdd => !(
            string.IsNullOrWhiteSpace(CatalogId.ToString())         || 
            string.IsNullOrWhiteSpace(UserId.ToString())            ||
            string.IsNullOrWhiteSpace(Amount.ToString())
        );
        #endregion
    }
}
