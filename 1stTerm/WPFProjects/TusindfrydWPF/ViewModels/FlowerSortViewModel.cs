﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TusindfrydWPF.Models;

namespace TusindfrydWPF.ViewModels
{
    public class FlowerSortViewModel
    {
        public FlowerSort Source { get; private set; }

        public string Name { get; set; }
        public string PicturePath { get; set; }
        public int ProductionTime { get; set; }
        public int HalfLifeTime { get; set; }
        public double Size { get; set; }

        public FlowerSortViewModel (FlowerSort flowerSort) {
            this.Source = flowerSort;
            
            Name = flowerSort.Name;
            PicturePath = flowerSort.PicturePath;
            ProductionTime = flowerSort.ProductionTime;
            HalfLifeTime = flowerSort.HalfLifeTime;
            Size = flowerSort.Size;
        }
    }
}
