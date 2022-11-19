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
                    
                    FlowerSort flowerSort = new FlowerSort(name, picturePath, productionTime, halfLifeTime, size);

                    flowerSorts.Add(flowerSort);
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
            FlowerSort flowerSort = new FlowerSort(name, picturePath, productionTime, halfLifeTime, size);

            flowerSorts.Add(flowerSort);

            return flowerSort;
        }

        public FlowerSort Retrieve (string name) {
            foreach (FlowerSort flowerSort in flowerSorts) {
                if (flowerSort.Name.Equals(name))
                    return flowerSort;
            }

            throw new ArgumentException("No flowersort named " + name + " exists in the repository.");
        }

        public List<FlowerSort> RetrieveAll () {
            return flowerSorts;
        }

        public void Update (string name, string picturePath, int productionTime, int halfLifeTime, double size) {
            foreach (FlowerSort flowerSort in flowerSorts) {
                if (flowerSort.Name.Equals(name)) {
                    flowerSort.PicturePath = picturePath;
                    flowerSort.ProductionTime = productionTime;
                    flowerSort.HalfLifeTime = halfLifeTime;
                    flowerSort.Size = size;
                }
            }
        }

        public void Delete (string name) {
            foreach (FlowerSort flowerSort in flowerSorts) {
                if (flowerSort.Name.Equals(name))
                    flowerSorts.Remove(flowerSort);
            }
        }
        #endregion
    }
}
