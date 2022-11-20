using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TusindfrydWPF.Models;

namespace TusindfrydWPF.ViewModels
{
    public class ProductionTrayViewModel
    {
        public ProductionTray Source { get; private set; } 

        public string Name { get; set; }
        public int Capacity { get; set; }

        public ProductionTrayViewModel(ProductionTray productionTray)
        {
            Source = productionTray;

            Name = productionTray.Name;
            Capacity = productionTray.Capacity;
        }
    }
}
