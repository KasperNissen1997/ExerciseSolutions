using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindfrydWPF.Models
{
    public class GreenhouseRepository
    {
        private string filePath = System.IO.Path.GetFullPath(@"..\..\..\Data\Greenhouses.csv");

        private List<Greenhouse> greenhouses;

        public GreenhouseRepository()
        {
            greenhouses = new List<Greenhouse>();

            Load();
        }

        public void Load()
        {
            greenhouses.Clear();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string[] readLine = sr.ReadLine().Split(';');

                    int number = int.Parse(readLine[0]);

                    Create(number);
                }
            }
        }

        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (Greenhouse greenhouse in greenhouses)
                {
                    sw.WriteLine(greenhouse.GetTitle());
                }
            }
        }

        #region CRUD
        public Greenhouse Create(int number)
        {
            foreach (Greenhouse greenhouse in greenhouses)
            {
                if (greenhouse.Number == number)
                    return greenhouse;
            }

            Greenhouse newGreenhouse = new Greenhouse(number);

            greenhouses.Add(newGreenhouse);

            return newGreenhouse;
        }

        public Greenhouse Retrieve(int iD)
        {
            foreach (Greenhouse greenhouse in greenhouses)
            {
                if (greenhouse.ID == iD)
                    return greenhouse;
            }

            throw new ArgumentException("No greenhouse with the ID " + iD + " exists in the repository.");
        }

        public List<Greenhouse> RetrieveAll()
        {
            return greenhouses;
        }

        public void Update(int iD, int number)
        {
            foreach (Greenhouse greenhouse in greenhouses)
            {
                if (greenhouse.ID == iD)
                {
                    greenhouse.Number = number;
                }
                
            }
        }

        public void Delete(int iD)
        {
            foreach (Greenhouse greenhouse in greenhouses)
            {
                if (greenhouse.ID == iD)
                    greenhouses.Remove(greenhouse);
            }
        }
        #endregion
    }
}
