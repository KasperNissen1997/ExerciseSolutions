using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TusindfrydWPF.Models;

namespace TusindfrydWPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private FlowerSortRepository flowerSortRepo;
        private GreenhouseRepository greenhouseRepo;
        private ProductionTrayRepository productionTrayRepo;
        private ProductionRepository productionRepo;

        public ObservableCollection<FlowerSortViewModel> FlowerSortVMs { get; set; }
        public ObservableCollection<ProductionViewModel> ProductionVMs { get; set; }
        public ObservableCollection<ProductionTrayViewModel> ProductionTrayVMs { get; set; }

        private FlowerSortViewModel _selectedFlowerSort;
        public FlowerSortViewModel SelectedFlowerSort {
            get {
                return _selectedFlowerSort;
            }
            set {
                _selectedFlowerSort = value;
                OnPropertyChanged(nameof(SelectedFlowerSort));
            }
        }

        private ProductionTrayViewModel _selectedProductionTray;
        public ProductionTrayViewModel SelectedProductionTray {
            get {
                return _selectedProductionTray;
            }
            set {
                _selectedProductionTray = value;
                OnPropertyChanged(nameof(SelectedProductionTray));
            }
        }

        public MainViewModel () {
            flowerSortRepo = new FlowerSortRepository();
            greenhouseRepo = new GreenhouseRepository();
            productionTrayRepo = new ProductionTrayRepository(greenhouseRepo);
            productionRepo = new ProductionRepository(flowerSortRepo, productionTrayRepo);

            FlowerSortVMs = new ObservableCollection<FlowerSortViewModel>();

            foreach (FlowerSort flowerSort in flowerSortRepo.RetrieveAll()) 
            {
                FlowerSortViewModel flowerSortVM = new FlowerSortViewModel(flowerSort);

                FlowerSortVMs.Add(flowerSortVM);
            }

            ProductionVMs = new ObservableCollection<ProductionViewModel>();

            foreach (Production production in productionRepo.RetrieveAll())
            {
                ProductionViewModel productionVM = new ProductionViewModel(production);

                ProductionVMs.Add(productionVM);
            }

            ProductionTrayVMs = new ObservableCollection<ProductionTrayViewModel>();

            foreach (ProductionTray productionTray in productionTrayRepo.RetrieveAll())
            {
                ProductionTrayViewModel productionTrayVM = new ProductionTrayViewModel(productionTray);

                ProductionTrayVMs.Add(productionTrayVM);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged (string propertyName) 
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null) 
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public void CreateFlowerSort (string name, string picturePath, int productionTime, int halfLifeTime, double size) 
        {
            FlowerSort flowerSort = flowerSortRepo.Create(name, picturePath, productionTime, halfLifeTime, size);
            FlowerSortViewModel flowerSortVM = new FlowerSortViewModel(flowerSort);

            FlowerSortVMs.Add(flowerSortVM);
        }

        public void CreateProduction (ProductionTrayViewModel productionTray, FlowerSortViewModel flowerSort, DateOnly date, int startAmount, int expectedAmount)
        {
            Production production = productionRepo.Create(date, startAmount, expectedAmount, false, flowerSort.Source, productionTray.Source);
            ProductionViewModel productionVM = new ProductionViewModel(production);

            ProductionVMs.Add(productionVM);
        }

        public void SaveAllRepositories() {
            flowerSortRepo.Save();
            productionTrayRepo.Save();
            productionRepo.Save();
        }
    }
}
