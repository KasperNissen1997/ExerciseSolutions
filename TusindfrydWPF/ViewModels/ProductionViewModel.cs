using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TusindfrydWPF.Models;

namespace TusindfrydWPF.ViewModels
{
    public class ProductionViewModel
    {
        private Production production;

        public ProductionTray Tray { get; set; }
        public FlowerSort FlowerSort { get; set; }

        public DateOnly Date { get; set; }
        public int StartAmount { get; set; }
        public int ExpectedAmount { get; set; }
        public bool IsFinished { get; set; }

        public ProductionViewModel(Production production)
        {
            this.production = production;

            Tray = production.Tray;
            FlowerSort = production.FlowerSort;

            Date = production.Date;
            StartAmount = production.StartAmount;
            ExpectedAmount = production.ExpectedAmount;
            IsFinished = production.IsFinished;
        }
    }
}
