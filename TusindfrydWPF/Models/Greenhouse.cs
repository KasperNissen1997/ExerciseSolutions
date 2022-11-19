using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindfrydWPF.Models
{
    public class Greenhouse
    {
        public int Number { get; set; }
        public List<ProductionTray> ProductionTrays { get; set; }

        public Greenhouse (int number) {
            ProductionTrays = new List<ProductionTray>();

            Number = number;
        }
    }
}
