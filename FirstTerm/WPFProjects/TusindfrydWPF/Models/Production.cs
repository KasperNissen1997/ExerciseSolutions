using System;

namespace TusindfrydWPF.Models
{
    public class Production
    {
        private static int iDCount = 0;

        public int ID { get; private set; }

        public ProductionTray Tray { get; set; }
        public FlowerSort FlowerSort { get; set; }

        public DateOnly Date { get; set; }
        public int StartAmount { get; set; }
        public int ExpectedAmount { get; set; }
        public bool IsFinished { get; set; }

        public Production (DateOnly date, int startAmount, int expectedAmount, bool isFinished, FlowerSort flowerSort, ProductionTray tray)
        {
            ID = iDCount++;

            Date = date;
            StartAmount = startAmount;
            ExpectedAmount = expectedAmount;
            IsFinished = isFinished;

            FlowerSort = flowerSort;
            Tray = tray;
        }

        public string GetTitle()
        {
            return string.Format($"{Date.ToString("dd-MM-yyyy")};{StartAmount};{ExpectedAmount};{IsFinished};{FlowerSort.ID};{Tray.ID}");
        }
    }
}
