using System;
using System.Windows.Input;
using Presentation.ViewModel.MVVMLight;

namespace Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _SelectedVM;
        private ICommand _SwitchViewCommand;

        public MainViewModel()
        {
            SelectedVM = new UserListViewModel();
            _SwitchViewCommand = new RelayCommand(view => { SwitchView(view.ToString()); });
        }

        public ViewModelBase SelectedVM
        {
            get => _SelectedVM;
            set
            {
                _SelectedVM = value;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }

        public ICommand SwitchViewCommand
        {
            get => _SwitchViewCommand;
        }

        public void SwitchView(string view)
        {
            switch (view)
            {
                case "UserListView":
                    SelectedVM = new UserListViewModel();
                    break;
                case "CatalogListView":
                    SelectedVM = new CatalogListViewModel();
                    break;
                case "EventListView":
                    SelectedVM = new EventListViewModel();
                    break;
            }
        }

    }
}
