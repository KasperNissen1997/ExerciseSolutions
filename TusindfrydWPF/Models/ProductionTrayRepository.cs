using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindfrydWPF.Models
{
    public class ProductionTrayRepository
    {
        private string filePath = System.IO.Path.GetFullPath(@"..\..\..\Data\ProductionTrays.csv");

        private List<ProductionTray> productionTrays;

        private GreenhouseRepository greenhouseRepo;

        public ProductionTrayRepository(GreenhouseRepository greenhouseRepo)
        {
            productionTrays = new List<ProductionTray>();

            this.greenhouseRepo = greenhouseRepo;

            Load();
        }

        public void Load()
        {
            productionTrays.Clear();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string[] readLine = sr.ReadLine().Split(';');

                    string name = readLine[0];
                    int capacity = int.Parse(readLine[1]);

                    Create(name, capacity);
                }
            }
        }

        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (ProductionTray productionTray in productionTrays)
                {
                    sw.WriteLine(productionTray.GetTitle());
                }
            }
        }

        #region CRUD
        public ProductionTray Create(string name, int capacity)
        {
            foreach (ProductionTray productionTray in productionTrays)
            {
                if (productionTray.Name.Equals(name))
                    return productionTray;
            }

            ProductionTray newproductionTray = new ProductionTray(name, capacity);

            productionTrays.Add(newproductionTray);

            return newproductionTray;
        }

        public ProductionTray Retrieve(int iD)
        {
            foreach (ProductionTray productionTray in productionTrays)
            {
                if (productionTray.ID == iD)
                    return productionTray;
            }

            throw new ArgumentException("No ProductionTray with the ID " + iD + " exists in the repository.");
        }

        public List<ProductionTray> RetrieveAll()
        {
            return productionTrays;
        }

        public void Update(int iD, string name, int capacity)
        {
            foreach (ProductionTray productionTray in productionTrays)
            {
                if (productionTray.ID == iD)
                {
                    productionTray.Name = name;
                    productionTray.Capacity = capacity;
                }

            }
        }

        public void Delete(int iD)
        {
            foreach (ProductionTray productionTray in productionTrays)
            {
                if (productionTray.ID == iD)
                    productionTrays.Remove(productionTray);
            }
        }
        #endregion
    }
}
