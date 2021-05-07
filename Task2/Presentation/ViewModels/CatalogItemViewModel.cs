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
    public class CatalogItemViewModel : ViewModelBase
    {
        #region properties
        private int _Id;
        private string _Name;
        private string _Genus;
        private int _Quantity;
        private int _Price;

        private CatalogCRUD _Service;
        private ICommand _UpdateCommand;
        #endregion


        public CatalogItemViewModel(int id, string name, string genus, int quantity, int price)
        {
            _Id = id;
            _Name = name;
            _Genus = genus;
            _Quantity = quantity;
            _Price = price;

            _Service = new CatalogCRUD();
            _UpdateCommand = new RelayCommand(e => { UpdateCatalog(); }, c => CanUpdate);
        }

        public CatalogItemViewModel()
        {
            _Service = new CatalogCRUD();
            _UpdateCommand = new RelayCommand(e => { UpdateCatalog(); }, c => CanUpdate);
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

        public int Quantity
        {
            get => _Quantity;
            set
            {
                _Quantity = value;

                OnPropertyChanged(nameof(Quantity));
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

        public ICommand UpdateCommand
        {
            get => _UpdateCommand;
        }

        public bool CanUpdate => !(
            string.IsNullOrWhiteSpace(Name)                 ||
            string.IsNullOrWhiteSpace(Genus)                ||
            string.IsNullOrWhiteSpace(Quantity.ToString())  ||
            string.IsNullOrWhiteSpace(Price.ToString())
        );
        #endregion

        #region PrivateMethods
        private void UpdateCatalog()
        {
            _Service.UpdateName(Id, Name);
            _Service.UpdateGenus(Id, Genus);
            _Service.UpdateQuantity(Id, Quantity);
            _Service.UpdatePrice(Id, Price);
        }
        #endregion
    }
}
