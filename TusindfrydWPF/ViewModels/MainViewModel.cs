using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TusindfrydWPF.Models;

namespace TusindfrydWPF.ViewModels
{
    public class MainViewModel
    {
        private FlowerSortRepository flowerSortRepo = new FlowerSortRepository();
        private ProductionRepository productionRepo = new ProductionRepository();
        private ProductionTrayRepository productionTrayRepo = new ProductionTrayRepository();

        public ObservableCollection<FlowerSortViewModel> FlowerSortVMs { get; set; }
        public ObservableCollection<ProductionViewModel> ProductionVMs { get; set; }
        public ObservableCollection<ProductionTrayViewModel> ProductionTrayVMs { get; set; }

        public MainViewModel () {
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

        public void CreateFlowerSort (string name, string picturePath, int productionTime, int halfLifeTime, double size) 
        {
            FlowerSort flowerSort = flowerSortRepo.Create(name, picturePath, productionTime, halfLifeTime, size);
            FlowerSortViewModel flowerSortVM = new FlowerSortViewModel(flowerSort);

            FlowerSortVMs.Add(flowerSortVM);
        }

        public void CreateProduction (DateOnly date, int startAmount, int expectedAmount)
        {
            Production production = productionRepo.Create(date, startAmount, expectedAmount, false);
            ProductionViewModel productionVM = new ProductionViewModel(production);

            ProductionVMs.Add(productionVM);
        }
    }
}
