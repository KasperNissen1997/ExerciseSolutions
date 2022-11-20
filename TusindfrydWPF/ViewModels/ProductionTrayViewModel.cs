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
        private ProductionTray productionTray; 

        public string Name { get; set; }
        public int Capacity { get; set; }

        public ProductionTrayViewModel(ProductionTray productionTray)
        {
            this.productionTray = productionTray;

            Name = productionTray.Name;
            Capacity = productionTray.Capacity;
        }
    }
}
