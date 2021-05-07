using Presentation.ViewModel.MVVMLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace Presentation.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {
        #region properties
        private string _FirstName;
        private string _LastName;

        private ICommand _AddCommand;
        private ICommand _DeleteCommand;

        private UserCRUD _Service;
        private ObservableCollection<UserItemViewModel> _UserViewModels;
        private UserItemViewModel _SelectedViewModel;
        private bool _IsUserViewModelSelected;
        #endregion


        public UserListViewModel()
        {
            _Service = new UserCRUD();
            _UserViewModels = new ObservableCollection<UserItemViewModel>();

            _AddCommand = new RelayCommand(e => { AddUser(); },
                condition => CanAdd);

            _DeleteCommand = new RelayCommand(e => { DeleteUser(); },
                condition => UserViewModelIsSelected());

            IsUserViewModelSelected = false;

            GetUsers();
        }



        #region private methods
        private void AddUser()
        {
            _Service.AddUser(FirstName, LastName);
            GetUsers();
        }

        private void DeleteUser()
        {
            _Service.DeleteUser(SelectedVM.Id);

            GetUsers();
            OnPropertyChanged(nameof(UserViewModels));
        }

        private void GetUsers()
        {
            _UserViewModels.Clear();

            foreach (var c in _Service.GetAllUsers())
            {
                _UserViewModels.Add(new UserItemViewModel(c.Id, c.FirstName, c.LastName));
            }

            OnPropertyChanged(nameof(UserViewModels));
        }

        private bool UserViewModelIsSelected()
        {
            return !(_SelectedViewModel is null);
        }
        #endregion



        #region API
        public string FirstName
        {
            get => _FirstName;
            set
            {
                _FirstName = value;

                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _LastName;
            set
            {
                _LastName = value;

                OnPropertyChanged(nameof(LastName));
            }
        }

        public ICommand AddCommand
        {
            get => _AddCommand;
        }

        public ICommand DeleteCommand
        {
            get => _DeleteCommand;
        }

        public bool IsUserViewModelSelected
        {
            get => _IsUserViewModelSelected;
            set
            {
                IsUserViewModelSelectedVisibility = value ? Visibility.Visible : Visibility.Hidden;
                _IsUserViewModelSelected = value;
                OnPropertyChanged(nameof(IsUserViewModelSelected));
            }
        }

        private Visibility _IsUserViewModelSelectedVisibility;

        public Visibility IsUserViewModelSelectedVisibility
        {
            get => _IsUserViewModelSelectedVisibility;
            set
            {
                _IsUserViewModelSelectedVisibility = value;
                OnPropertyChanged(nameof(IsUserViewModelSelectedVisibility));
            }
        }

        public ObservableCollection<UserItemViewModel> UserViewModels
        {
            get => _UserViewModels;

            set
            {
                _UserViewModels = value;
                OnPropertyChanged(nameof(UserViewModels));
            }
        }

        public UserItemViewModel SelectedVM
        {
            get => _SelectedViewModel;
            set
            {
                _SelectedViewModel = value;
                IsUserViewModelSelected = true;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }

        public bool CanAdd => !(string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName));
        #endregion
    }
}
