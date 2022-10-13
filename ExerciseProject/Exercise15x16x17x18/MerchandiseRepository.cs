using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseProject.Exercise15x16x17x18
{
    public class MerchandiseRepository
    {
        List<Merchandise> merchandises = new List<Merchandise>();

        public void AddMerchandise (Merchandise merchandise) {
            merchandises.Add(merchandise);
        }

        public Merchandise GetMerchandise (string itemId) {
            foreach (Merchandise merchandise in merchandises) {
                if (merchandise.ItemId == itemId)
                    return merchandise;
            }

            return null;
        }

        public double GetTotalValue () {
            Utility util = new Utility();

            double totalValue = 0;

            foreach (Merchandise merchandise in merchandises) {
                totalValue += util.GetValueOfMerchandise(merchandise);
            }

            return totalValue;
        }
    }
}
