using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCommandBinding.Models;
using WPFCommandBinding.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WPFCommandBinding.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProductVM> ProductVMs { get; set; }

        private ProductVM _selectedPerson;
        public ProductVM SelectedProduct {
            get { return _selectedPerson; }
            set { 
                _selectedPerson = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        #region Commands
        public CreateProductCommand CreateProductCommand { get; } = new CreateProductCommand();
        public DeleteProductCommand DeleteProductCommand { get; } = new DeleteProductCommand();
        #endregion

        public MainViewModel () {
            ProductVMs = new ObservableCollection<ProductVM>();

            foreach (Product product in ProductRepository.Instance.RetrieveAll()) {
                ProductVM productVM = new ProductVM(product);

                ProductVMs.Add(productVM);
            }
        }

        #region Interface implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged (string propertyName) {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;

            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public void CreateProduct () {
            Product product = ProductRepository.Instance.Create("New Product", 0);

            ProductVM productVM = new ProductVM(product);

            ProductVMs.Add(productVM);
            SelectedProduct = productVM;
        }

        public void DeleteProduct () {
            SelectedProduct.DeleteFromRepo();
            ProductVMs.Remove(SelectedProduct);

            SelectedProduct = null;
        }
    }
}
