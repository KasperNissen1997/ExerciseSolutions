using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TusindfrydWPF.Models;

namespace TusindfrydWPF.ViewModels
{
    public class MainViewModel
    {
        private FlowerSortRepository flowerSortRepo = new FlowerSortRepository();

        public List<FlowerSortViewModel> FlowerSortVMs;

        public MainViewModel () {
            FlowerSortVMs = new List<FlowerSortViewModel>();

            foreach (FlowerSort flowerSort in flowerSortRepo.RetrieveAll()) {
                FlowerSortViewModel flowerSortVM = new FlowerSortViewModel(flowerSort);

                FlowerSortVMs.Add(flowerSortVM);
            }
        }

        public void CreateFlowerSort (string name, string picturePath, int productionTime, int halfLifeTime, double size) {
            FlowerSort flowerSort = flowerSortRepo.Create(name, picturePath, productionTime, halfLifeTime, size);
            FlowerSortViewModel flowerSortVM = new FlowerSortViewModel(flowerSort);

            FlowerSortVMs.Add(flowerSortVM);
        }
    }
}
