using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindfrydWPF.Models
{
    public class ProductionRepository
    {
        private string filePath = System.IO.Path.GetFullPath(@"..\..\..\Data\Productions.csv");

        private List<Production> productions;

        public ProductionRepository()
        {
            productions = new List<Production>();

            Load();
        }

        public void Load()
        {
            productions.Clear();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string[] readLine = sr.ReadLine().Split(';');

                    DateOnly date = DateOnly.Parse(readLine[0]);
                    int startAmount = int.Parse(readLine[1]);
                    int expectedAmount = int.Parse(readLine[2]);
                    bool isFinished = bool.Parse(readLine[3]);

                    Create(date, startAmount, expectedAmount, isFinished);
                }
            }
        }

        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (Production production in productions)
                {
                    sw.WriteLine(production.GetTitle());
                }
            }
        }

        #region CRUD
        public Production Create(DateOnly date, int startAmount, int expectedAmount, bool isFinished)
        {
            Production newProduction = new Production(date, startAmount, expectedAmount, isFinished);

            productions.Add(newProduction);

            return newProduction;
        }

        public Production Retrieve(int iD)
        {
            foreach (Production production in productions)
            {
                if (production.ID == iD)
                    return production;
            }

            throw new ArgumentException("No production with the ID " + iD + " exists in the repository.");
        }

        public List<Production> RetrieveAll()
        {
            return productions;
        }

        public void Update(int iD, DateOnly date, int startAmount, int expectedAmount, bool isFinished)
        {
            foreach (Production production in productions)
            {
                if (production.ID == iD)
                {
                    production.Date = date;
                    production.StartAmount = startAmount;
                    production.ExpectedAmount = expectedAmount;
                    production.IsFinished = isFinished;
                }
            }
        }

        public void Delete(int iD)
        {
            foreach (Production production in productions)
            {
                if (production.ID == iD)
                    productions.Remove(production);
            }
        }
        #endregion
    }
}
