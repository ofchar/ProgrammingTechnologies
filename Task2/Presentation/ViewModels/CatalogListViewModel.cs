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
    public class CatalogListViewModel : ViewModelBase
    {
        #region properties
        private string _Name;
        private string _Genus;
        private int _Price;

        private ICommand _AddCommand;
        private ICommand _DeleteCommand;

        private CatalogCRUD _Service;
        private ObservableCollection<CatalogItemViewModel> _CatalogViewModels;
        private CatalogItemViewModel _SelectedViewModel;
        private bool _IsCatalogViewModelSelected;
        #endregion


        public CatalogListViewModel()
        {
            _Service = new CatalogCRUD();
            _CatalogViewModels = new ObservableCollection<CatalogItemViewModel>();

            _AddCommand = new RelayCommand(e => { AddCatalog(); },
                condition => CanAdd);

            _DeleteCommand = new RelayCommand(e => { DeleteCatalog(); },
                condition => CatalogViewModelIsSelected());

            IsCatalogViewModelSelected = false;

            GetCatalogs();
        }



        #region private methods
        private void AddCatalog()
        {
            _Service.AddCatalog(Name, Genus, Price);
            GetCatalogs();
        }

        private void DeleteCatalog()
        {
            _Service.DeleteCatalog(SelectedVM.Id);

            GetCatalogs();
            OnPropertyChanged(nameof(CatalogViewModels));
        }

        private void GetCatalogs()
        {
            _CatalogViewModels.Clear();

            foreach (var c in _Service.GetAllCatalogs())
            {
                _CatalogViewModels.Add(new CatalogItemViewModel(c.Id, c.Name, c.Genus, c.Quantity, c.Price));
            }

            OnPropertyChanged(nameof(CatalogViewModels));
        }

        private bool CatalogViewModelIsSelected()
        {
            return !(_SelectedViewModel is null);
        }
        #endregion



        #region API
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;

                OnPropertyChanged(nameof(Name));
            }
        }

        public string Genus
        {
            get => _Genus;
            set
            {
                _Genus = value;

                OnPropertyChanged(nameof(Genus));
            }
        }

        public int Price
        {
            get => _Price;
            set
            {
                _Price = value;

                OnPropertyChanged(nameof(Price));
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

        public bool IsCatalogViewModelSelected
        {
            get => _IsCatalogViewModelSelected;
            set
            {
                IsCatalogViewModelSelectedVisibility = value ? Visibility.Visible : Visibility.Hidden;
                _IsCatalogViewModelSelected = value;
                OnPropertyChanged(nameof(IsCatalogViewModelSelected));
            }
        }

        private Visibility _IsCatalogViewModelSelectedVisibility;

        public Visibility IsCatalogViewModelSelectedVisibility
        {
            get => _IsCatalogViewModelSelectedVisibility;
            set
            {
                _IsCatalogViewModelSelectedVisibility = value;
                OnPropertyChanged(nameof(IsCatalogViewModelSelectedVisibility));
            }
        }

        public ObservableCollection<CatalogItemViewModel> CatalogViewModels
        {
            get => _CatalogViewModels;

            set
            {
                _CatalogViewModels = value;
                OnPropertyChanged(nameof(CatalogViewModels));
            }
        }

        public CatalogItemViewModel SelectedVM
        {
            get => _SelectedViewModel;
            set
            {
                _SelectedViewModel = value;
                IsCatalogViewModelSelected = true;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }

        public bool CanAdd => !(
            string.IsNullOrWhiteSpace(Name)             ||
            string.IsNullOrWhiteSpace(Genus)            ||
            string.IsNullOrWhiteSpace(Price.ToString())
        );
        #endregion
    }
}
