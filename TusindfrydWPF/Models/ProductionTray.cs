using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindfrydWPF.Models
{
    public class ProductionTray
    {
        private static int iDCount = 0;

        public int ID { get; private set; }

        public Greenhouse Greenhouse { get; set; }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public ProductionTray (string name, int capacity) {
            ID = iDCount++;

            Name = name;
            Capacity = capacity;
        }

        public string GetTitle()
        {
            return string.Format($"{Name};{Capacity}");
        }
    }
}
