using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindfrydWPF.Models
{
    public class Greenhouse
    {
        private static int iDCount = 0;

        public int ID { get; private set; }

        public List<ProductionTray> ProductionTrays { get; set; }

        public int Number { get; set; }

        public Greenhouse (int number) {
            ID = iDCount++;

            ProductionTrays = new List<ProductionTray>();

            Number = number;
        }

        public string GetTitle()
        {
            return string.Format($"{Number}");
        }
    }
}
