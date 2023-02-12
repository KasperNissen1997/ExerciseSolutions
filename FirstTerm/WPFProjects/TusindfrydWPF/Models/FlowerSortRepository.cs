using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindfrydWPF.Models
{
    public class FlowerSortRepository
    {
        private string filePath = System.IO.Path.GetFullPath(@"..\..\..\Data\FlowerSorts.csv");

        private List<FlowerSort> flowerSorts;

        public FlowerSortRepository () {
            flowerSorts = new List<FlowerSort>();

            Load();
        }

        public void Load () {
            flowerSorts.Clear();

            using (StreamReader sr = new StreamReader(filePath)) {
                while (!sr.EndOfStream) {
                    string[] readLine = sr.ReadLine().Split(';');

                    string name = readLine[0];
                    string picturePath = readLine[1];
                    int productionTime = int.Parse(readLine[2]);
                    int halfLifeTime = int.Parse(readLine[3]);
                    double size = double.Parse(readLine[4]);

                    Create(name, picturePath, productionTime, halfLifeTime, size);
                }
            }
        }

        public void Save () {
            using (StreamWriter sw = new StreamWriter(filePath, false)) {
                foreach (FlowerSort flowerSort in flowerSorts) {
                    sw.WriteLine(flowerSort.GetTitle());
                }
            }
        }

        #region CRUD
        public FlowerSort Create (string name, string picturePath, int productionTime, int halfLifeTime, double size) {
            FlowerSort newFlowerSort = new FlowerSort(name, picturePath, productionTime, halfLifeTime, size);

            foreach (FlowerSort flowerSort in flowerSorts)
            {
                if (newFlowerSort.Equals(flowerSort))
                    return flowerSort;
            }

            flowerSorts.Add(newFlowerSort);

            return newFlowerSort;
        }

        public FlowerSort Retrieve (int iD) {
            foreach (FlowerSort flowerSort in flowerSorts) {
                if (flowerSort.ID == iD)
                    return flowerSort;
            }

            throw new ArgumentException("No flowersort with ID " + iD + " exists in the repository.");
        }

        public List<FlowerSort> RetrieveAll () {
            return flowerSorts;
        }

        public void Update (int iD, string name, string picturePath, int productionTime, int halfLifeTime, double size) {
            foreach (FlowerSort flowerSort in flowerSorts) {
                if (flowerSort.ID == iD) {
                    flowerSort.Name = name;
                    flowerSort.PicturePath = picturePath;
                    flowerSort.ProductionTime = productionTime;
                    flowerSort.HalfLifeTime = halfLifeTime;
                    flowerSort.Size = size;
                }
            }
        }

        public void Delete (int iD) {
            foreach (FlowerSort flowerSort in flowerSorts) {
                if (flowerSort.ID == iD)
                    flowerSorts.Remove(flowerSort);
            }
        }
        #endregion
    }
}
