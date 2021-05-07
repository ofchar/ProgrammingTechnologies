using Presentation.ViewModel.MVVMLight;
using Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class UserItemViewModel : ViewModelBase
    {
        #region properties
        private int _Id;
        private string _FirstName;
        private string _LastName;

        private UserCRUD _Service;
        private ICommand _UpdateCommand;
        #endregion


        public UserItemViewModel(int id, string firstName, string lastName)
        {
            _Id = id;
            _FirstName = firstName;
            _LastName = lastName;

            _Service = new UserCRUD();
            _UpdateCommand = new RelayCommand(e => { UpdateUser(); }, c => CanUpdate);
        }

        public UserItemViewModel()
        {
            _Service = new UserCRUD();
            _UpdateCommand = new RelayCommand(e => { UpdateUser(); }, c => CanUpdate);
        }



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

        public ICommand UpdateCommand
        {
            get => _UpdateCommand;
        }

        public bool CanUpdate => !(
            string.IsNullOrWhiteSpace(FirstName) || 
            string.IsNullOrWhiteSpace(LastName)
        );
        #endregion

        #region PrivateMethods
        private void UpdateUser()
        {
            _Service.UpdateFirstName(Id, FirstName);
            _Service.UpdateLastName(Id, LastName);
        }
        #endregion
    }
}
