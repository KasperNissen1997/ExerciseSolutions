using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindfrydWPF.Models
{
    public class ProductionTray
    {
        private Greenhouse greenhouse;

        public string Name { get; set; }
        public int Capacity { get; set; }

        public ProductionTray (Greenhouse greenhouse, string name, int capacity) {
            this.greenhouse = greenhouse;

            Name = name;
            Capacity = capacity;
        }
    }
}
